using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas.Models
{
    // Modelo para representar el tablero de juego
    internal class BoardModel
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int NumMines { get; set; }
        public CellModel[,] Cells { get; private set; } 

        public BoardModel()
        {
            Cells = new CellModel[Rows, Columns];
            InitializeCells();
        }

        // Inicializa cada celda del tablero
        protected void InitializeCells()
        {
            Cells = new CellModel[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Cells[i, j] = new CellModel();
                }
            }
        }

    }
}
