using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Buscaminas.Models
{
    internal class GameModel : BoardModel
    {

        public void SetDifficulty(string difficulty)
        {   
            
            switch (difficulty.ToLower())
            {
                case "easy":
                    NumMines = 15;
                    break;
                case "medium":
                    NumMines = 50;
                    break;
                case "hard":
                    NumMines = 99;
                    break;
            }

        }

        public void StartGame(string difficulty)
        {
            SetDifficulty(difficulty);
            InitializeCells();       
            MinesAssignment();       
            AdjacentMinesAssignment(); 
        }

        public void MinesAssignment()
        {
            Random random = new Random();
            int Mines = 0;

            while (Mines < NumMines)
            {
                 int row = random.Next(0, Rows);
                 int column = random.Next(0, Columns);

                if (Cells[row, column].IsMine != true)
                {
                    Cells[row, column].IsMine = true;
                    Mines++;
                }
            }

        }

        public void AdjacentMinesAssignment()
        {
            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                    if (Cells[i,j].IsMine == true)
                    {
                        IncrementIfValid(i + 1, j);
                        IncrementIfValid(i - 1, j);
                        IncrementIfValid(i, j + 1);
                        IncrementIfValid(i, j - 1);
                        IncrementIfValid(i + 1, j + 1);
                        IncrementIfValid(i + 1, j - 1);
                        IncrementIfValid(i - 1, j + 1);
                        IncrementIfValid(i - 1, j - 1);
                    }
                }
            }
        }

        private void IncrementIfValid(int row, int column)
        {
            if (row >= 0 && row < Rows && column >= 0 && column < Columns)
                Cells[row, column].AdjacentMines++;
        }

        public bool SafeCell()
        {         
               for(int i = 0; i < Rows; i++)              
                    for(int j = 0; j < Columns; j++)
                    
                        if (!Cells[i, j].IsMine && Cells[i, j].AdjacentMines == 0)                                                 
                            return true;                                                     
           
            return false;
        }

        public void RevealCell(int row, int column)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                return;

            if (Cells[row, column].IsRevealed || Cells[row, column].IsFlagged)
                return;

            Cells[row, column].IsRevealed = true;
            
            if (Cells[row, column].AdjacentMines == 0)
            {
                RevealCell(row + 1, column);
                RevealCell(row - 1, column);
                RevealCell(row, column + 1);
                RevealCell(row, column - 1);
                RevealCell(row + 1, column + 1);
                RevealCell(row + 1, column - 1);
                RevealCell(row - 1, column + 1);
                RevealCell(row - 1, column - 1);
            }
        }

        public bool CheckVictory()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    if (!Cells[i, j].IsMine && !Cells[i, j].IsRevealed)
                        return false;

            return true;
        }

    }
}
