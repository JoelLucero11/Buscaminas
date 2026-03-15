using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas.Models
{

    // Modelo para representar cada celda del tablero
    class CellModel
    {
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }
        public int AdjacentMines { get; set; }
        public CellModel()
        {
            IsMine = false;
            IsRevealed = false;
            IsFlagged = false;
            AdjacentMines = 0;
        }

    }
}
