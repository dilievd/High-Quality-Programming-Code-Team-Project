using System;

namespace Labyrinth
{
    public class Cell
    {
        private int row;
        private int column;
        private char symbol;

        public Cell(int row, int column, char symbol)
        {
            this.Row = row;
            this.Column = column;
            this.Symbol = symbol;
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalid input! Row must be non-negative number");
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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalid input! Column must be non-negative number");
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
                if (char.IsWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Symbol could not be white space");
                }

                this.symbol = value;
            }
        }
    }
}