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

        /// <summary>
        /// Create cell
        /// </summary>
        /// <param name="row">Row of the cell</param>
        /// <param name="column">Column of the cell</param>
        /// <param name="symbol">Symbol of the cell</param>
        public Cell(int row, int column, char symbol)
        {
            this.Row = row;
            this.Column = column;
            this.Symbol = symbol;
        }

        /// <summary>
        /// Represent cell's row in the labyrinth
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the row is a number outside the interval [0, Engine.LABYRINTH_SIZE]</exception>
        public int Row
        {
            get
            {
                return this.row;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Row number must be non-negative number!");
                }
                else if (value >= Engine.LABYRINTH_SIZE)
                {
                    throw new ArgumentOutOfRangeException(
                        "Row number can not exceed the size of the labyrinth!");
                }

                this.row = value;
            }
        }

        /// <summary>
        /// Represent cell's column in the labyrinth
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the column is a number outside the interval [0, Engine.LABYRINTH_SIZE]</exception>
        public int Column
        {
            get
            {
                return this.column;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Column number must be non-negative number!");
                }
                else if (value >= Engine.LABYRINTH_SIZE)
                {
                    throw new ArgumentOutOfRangeException(
                        "Column number can not exceed the size of the labyrinth!");
                }

                this.column = value;
            }
        }

        /// <summary>
        /// Represent cell's symbol in the labyrinth
        /// </summary>
        /// <exception cref="ArgumentException">
        /// If the symbol is white space</exception>
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
                        "Symbol cannot be white space");
                }

                this.symbol = value;
            }
        }
    }
}