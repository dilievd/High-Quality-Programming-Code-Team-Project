using System;
using System.Collections.Generic;

namespace Labyrinth
{
    class Labyrinth
    {
        public const char PLAYER = '*';
        public const int LABYRINTH_SIZE = 7;
        private readonly int StartRow = LABYRINTH_SIZE / 2;
        private readonly int StartColumn = LABYRINTH_SIZE / 2;
        private Cell[,] labyrinth;
        public Cell currentCell;

        public Labyrinth(Random rand)
        {
            GenerateLabyrinth(rand);
            currentCell = labyrinth[StartRow, StartRow];
        }

        public bool TryMove(Cell cell, Direction direction)
        {
            Cell nextCell = FindNextCell(cell, direction);

            if (nextCell.Row < 0 || nextCell.Column < 0 ||
                nextCell.Row >= labyrinth.GetLength(0) || nextCell.Column >= labyrinth.GetLength(1))
            {
                return false;
            }

            if (!labyrinth[nextCell.Row, nextCell.Column].IsEmpty())
            {
                return false;
            }

            this.labyrinth[nextCell.Row, nextCell.Column] = nextCell;
            this.currentCell = nextCell;
            this.labyrinth[cell.Row, cell.Column].Symbol = '-';
            return true;
        }

        private Cell FindNextCell(Cell cell, Direction direction)
        {
            Cell nextCell = new Cell(cell.Row, cell.Column, cell.Symbol);

            if (direction == Direction.Up)
            {
                nextCell.Row--;
            }
            else if (direction == Direction.Down)
            {
                nextCell.Row++;
            }
            else if (direction == Direction.Left)
            {
                nextCell.Column--;
            }
            else if (direction == Direction.Right)
            {
                nextCell.Column++;
            }

            return nextCell;
        }

        private void premestvane(Cell cell, Direction direction,
            Queue<Cell> cellsOrder, HashSet<Cell> visitedCells)
        {
            Cell nextCell = FindNextCell(cell, direction);

            if (nextCell.Row < 0 || nextCell.Column < 0 ||
                nextCell.Row >= labyrinth.GetLength(0) || nextCell.Column >= labyrinth.GetLength(1))
            {
                return;
            }

            if (visitedCells.Contains(labyrinth[nextCell.Row, nextCell.Column]))
            {
                return;
            }

            if (labyrinth[nextCell.Row, nextCell.Column].IsEmpty())
            {
                cellsOrder.Enqueue(labyrinth[nextCell.Row, nextCell.Column]);
            }
        }

        private bool ExitFound(Cell cell)
        {
            bool exitFound = false;
            if (cell.Row == LABYRINTH_SIZE - 1 ||
                cell.Column == LABYRINTH_SIZE - 1 ||
                cell.Row == 0 ||
                cell.Column == 0)
            {
                exitFound = true;
            }

            return exitFound;
        }

        private bool ExitPathExists()
        {
            Queue<Cell> cellsOrder = new Queue<Cell>();
            Cell startCell = labyrinth[StartRow, StartColumn];
            cellsOrder.Enqueue(startCell);
            HashSet<Cell> visitedCells = new HashSet<Cell>();
            bool pathExists = false;

            while (cellsOrder.Count > 0)
            {
                Cell currentCell = cellsOrder.Dequeue();
                visitedCells.Add(currentCell);
                if (ExitFound(currentCell))
                {
                    pathExists = true;
                    break;
                }

                premestvane(currentCell, Direction.Down, cellsOrder,visitedCells);
                premestvane(currentCell, Direction.Up, cellsOrder, visitedCells);
                premestvane(currentCell, Direction.Left, cellsOrder, visitedCells);
                premestvane(currentCell, Direction.Right, cellsOrder, visitedCells);
            }

            return pathExists;
        }

        private void GenerateLabyrinth(Random rand)
        {
            this.labyrinth = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];

            for (int row = 0; row < LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < LABYRINTH_SIZE; column++)
                {
                    int randomValue = rand.Next(0, 2);
                    char charValue;
                    if (randomValue == 0)
                    {
                        charValue = Cell.EMPTY_CELL;
                    }
                    else
                    {
                        charValue = Cell.WALL_CELL;
                    }

                    this.labyrinth[row,column] = new Cell(row, column, charValue);
                }
            }

            this.labyrinth[StartRow, StartColumn].Symbol = Labyrinth.PLAYER;
            bool exitPathExists = ExitPathExists();
            if (!exitPathExists)
            {
                GenerateLabyrinth(rand);
            }
        }

        public void PrintLabyrinth()
        {
            for (int row = 0; row < Labyrinth.LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < Labyrinth.LABYRINTH_SIZE; column++)
                {
                    Cell cell = this.labyrinth[row, column];
                    Console.Write(cell.Symbol + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
