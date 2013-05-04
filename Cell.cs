using System;

namespace Labyrinth
{
    class Cell
    {
        public const char EMPTY_CELL = '-';
        public const char WALL_CELL = 'X';

        public int Row { get; set; }
        public int Col { get; set; }
        public char Symbol { get; set; }

        public Cell(int row, int col, char symbol)
        {
            this.Row = row;
            this.Col = col;
            this.Symbol = symbol;
        }

        public bool IsEmpty()
        {
            if(this.Symbol == EMPTY_CELL)
            {
                return true;
            }

            return false;
        }
    }
}
