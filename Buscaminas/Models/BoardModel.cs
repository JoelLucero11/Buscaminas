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
        private int _rows;
        private int _columns;
        public int NumMines { get; set; }
        public CellModel[,] Cells { get; private set; } 

        public BoardModel()
        {
            Rows = 15;
            Columns = 15;
            NumMines = 0;
            Cells = new CellModel[Rows, Columns];
            InitializeCells();
        }

        public int Rows
        {
            get => _rows;
            set
            {
                _rows = value < 0 ? 0 : value;
                _rows = value > 15 ? 15 : value;
            }
        }

        public int Columns
        {
            get => _columns;
            set
            {
                _columns = value < 0 ? 0 : value;
                _columns = value > 15 ? 15 : value;
            }
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
