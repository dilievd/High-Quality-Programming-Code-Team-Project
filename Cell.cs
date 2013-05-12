using System;

namespace Labyrinth
{
    public class Cell
    {
        public const char EMPTY_CELL = '-';
        public const char WALL_CELL = 'X';
        public const char PLAYER = '*';

        private int row;
        private int column;
        private char symbol;

        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            this.symbol = Cell.PLAYER;
        }

        public Cell(int row, int column, char symbol)
            : this(row, column)
        {
            this.symbol = symbol;
        }

        public Cell(int row, int column, int randomValue)
            : this(row, column)
        {
            if (randomValue == 0)
            {
                this.symbol = Cell.EMPTY_CELL;
            }
            else
            {
                this.symbol = Cell.WALL_CELL;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0 || LabyrinthEngine.LABYRINTH_SIZE <= value)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Row number must be in range [0..{0}]", LabyrinthEngine.LABYRINTH_SIZE - 1));
                }

                this.row = value;
            }
        }

        public int Column
        {
            get
            {
                return this.column;
            }

            set
            {
                if (value < 0 || LabyrinthEngine.LABYRINTH_SIZE <= value)
                {
                    throw new ArgumentOutOfRangeException(string.Format(
                        "Column number must be in range [0..{0}]", LabyrinthEngine.LABYRINTH_SIZE - 1));
                }

                this.column = value;
            }
        }

        public char Symbol
        {
            get
            {
                return this.symbol;
            }

            private set
            {
                if (!(value == EMPTY_CELL || value == WALL_CELL || value == PLAYER))
                {
                    throw new ArgumentException(string.Format(
                        "Symbol could not be {0}, it must be {1} or {2} or {3}, ", value, EMPTY_CELL, WALL_CELL, PLAYER));
                }

                this.symbol = value;
            }
        }

        public bool IsEmpty()
        {
            if (this.Symbol == EMPTY_CELL)
            {
                return true;
            }

            return false;
        }
    }
}