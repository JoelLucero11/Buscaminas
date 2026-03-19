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
        public bool IsMine { get; set; } = false;
        public bool IsRevealed { get; set; } = false;
        public bool IsFlagged { get; set; } = false;
        public int AdjacentMines { get; set; } = 0;
        public bool IsSafe { get; set; } = false;

    }
}
