using System;

namespace Labyrinth
{
    class Cell
    {
        public const char EMPTY_CELL = '-';
        public const char WALL_CELL = 'X';
        public const char PLAYER = '*';

        public int Row { get; set; }
        public int Column { get; set; }
        public char Symbol { get; set; }

        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            this.Symbol = Cell.PLAYER;
        }

        public Cell(int row, int column, char symbol) 
            : this(row, column)
        {
            this.Symbol = symbol;
        }

        public Cell(int row, int column, int randomValue)
            : this(row, column)
        {
            if (randomValue == 0)
            {
                this.Symbol = Cell.EMPTY_CELL;
            }
            else
            {
                this.Symbol = Cell.WALL_CELL;
            }
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
