using System;

namespace Labyrinth
{
    /// <summary>
    /// Represent cell from the labyrinth
    /// </summary>
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

        /// <summary>
        /// Represent cell's row in the labyrinth
        /// </summary>
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

        /// <summary>
        /// Represent cell's column in the labyrinth
        /// </summary>
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

        /// <summary>
        /// Represent cell's symbol in the labyrinth
        /// </summary>
        public char Symbol
        {
            get
            {
                return this.symbol;
            }

            set
            {
                if (char.IsWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Invalid input! Symbol cannot be white space");
                }

                this.symbol = value;
            }
        }
    }
}