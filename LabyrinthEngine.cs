using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public class LabyrinthEngine
    {
        private const char EMPTY_CELL = '-';
        private const char WALL_CELL = 'X';
        private const char PLAYER = '*';
        private const char VISITED = 'v';
        public const int LABYRINTH_SIZE = 7;
        private readonly int startRow = LABYRINTH_SIZE / 2;
        private readonly int startColumn = LABYRINTH_SIZE / 2;

        private Cell[,] labyrinth = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];
        private Cell[,] dummyLabyrinth = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];
        private Random rand = new Random();
        private bool exitFound = false;

        public Cell CurrentCell { get; private set; }

        public LabyrinthEngine()
        {
            this.CurrentCell = new Cell(this.startRow, this.startColumn, PLAYER);
            this.GenerateLabyrinth();
        }

        private void GenerateLabyrinth()
        {
            do
            {
                this.CreateLabyrinth();
                this.HasExit(this.CurrentCell);
            } while (!this.exitFound);
        }

        private void CreateLabyrinth()
        {
            for (int row = 0; row < LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < LABYRINTH_SIZE; column++)
                {
                    int randomValue = rand.Next(0, 2);
                    if (randomValue == 0)
                    {
                        this.labyrinth[row, column] = new Cell(row, column, EMPTY_CELL);
                        this.dummyLabyrinth[row, column] = new Cell(row, column, EMPTY_CELL);
                    }
                    else
                    {
                        this.labyrinth[row, column] = new Cell(row, column, WALL_CELL);
                        this.dummyLabyrinth[row, column] = new Cell(row, column, WALL_CELL);
                    }
                }
            }

            this.labyrinth[this.startRow, this.startColumn] = new Cell(this.startRow, this.startColumn, PLAYER);
            this.dummyLabyrinth[this.startRow, this.startColumn] = new Cell(this.startRow, this.startColumn, PLAYER);
        }

        private void HasExit(Cell cell)
        {
            char currentSymbol = cell.Symbol;
            this.dummyLabyrinth[cell.Row, cell.Column].Symbol = VISITED;
            if (currentSymbol == EMPTY_CELL || currentSymbol == PLAYER)
            {
                if (this.ExitFound(cell))
                {
                    this.exitFound = true;
                    return;
                }

                if (!this.exitFound)
                {
                    this.HasExit(this.dummyLabyrinth[cell.Row, cell.Column - 1]); //left
                    this.HasExit(this.dummyLabyrinth[cell.Row, cell.Column + 1]); // up
                    this.HasExit(this.dummyLabyrinth[cell.Row - 1, cell.Column]); // right                   
                    this.HasExit(this.dummyLabyrinth[cell.Row + 1, cell.Column]); // down
                }
            }
        }

        public bool TryMove(Cell cell, Direction direction)
        {
            Cell nextCell = new Cell(cell.Row + direction.X, cell.Column + direction.Y, cell.Symbol);
            bool moveDone = false;
            bool isEmpty = this.labyrinth[nextCell.Row, nextCell.Column].Symbol == EMPTY_CELL;
            if (isEmpty)
            {
                moveDone = true;
                this.CurrentCell = nextCell;
                this.labyrinth[nextCell.Row, nextCell.Column].Symbol = PLAYER;
                this.labyrinth[cell.Row, cell.Column].Symbol = EMPTY_CELL;
            }

            return moveDone;
        }

        public bool ExitFound(Cell cell)
        {
            bool exitFound = false;
            bool rowBorder = (cell.Row == LABYRINTH_SIZE - 1 || cell.Row == 0);
            bool columnBorder = (cell.Column == LABYRINTH_SIZE - 1 || cell.Column == 0);
            if (rowBorder || columnBorder)
            {
                exitFound = true;
            }

            return exitFound;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < LABYRINTH_SIZE; column++)
                {
                    Cell cell = this.labyrinth[row, column];
                    result.Append(cell.Symbol + " ");
                }

                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
