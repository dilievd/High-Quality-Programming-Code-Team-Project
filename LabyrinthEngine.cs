using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    class LabyrinthEngine
    {
        public const int LABYRINTH_SIZE = 7;
        private readonly int startRow = LABYRINTH_SIZE / 2;
        private readonly int startColumn = LABYRINTH_SIZE / 2;

        private Cell[,] labyrinth;

        public Cell CurrentCell { get; private set; }

        public LabyrinthEngine(Random rand)
        {
            GenerateLabyrinth(rand);
            CurrentCell = labyrinth[this.startRow, this.startRow];
        }

        private void GenerateLabyrinth(Random rand)
        {
            CreateLabyrinth(rand);
            if (!this.IsExitPath())
            {
                GenerateLabyrinth(rand);
            }
        }

        private void CreateLabyrinth(Random rand)
        {
            this.labyrinth = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];
            for (int row = 0; row < LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < LABYRINTH_SIZE; column++)
                {
                    int randomValue = rand.Next(0, 2);
                    this.labyrinth[row, column] = new Cell(row, column, randomValue);
                }
            }

            this.labyrinth[this.startRow, this.startColumn] = new Cell(this.startRow, this.startColumn);
        }

        private bool IsExitPath()
        {
            Queue<Cell> cellsOrder = new Queue<Cell>();
            Cell startCell = labyrinth[this.startRow, this.startColumn];
            cellsOrder.Enqueue(startCell);
            HashSet<Cell> visitedCells = new HashSet<Cell>();
            bool isExitPath = false;
            while (cellsOrder.Count > 0)
            {
                Cell currentCell = cellsOrder.Dequeue();
                visitedCells.Add(currentCell);
                if (ExitFound(currentCell))
                {
                    isExitPath = true;
                    break;
                }

                AddNeighbor(currentCell, Direction.Down, cellsOrder, visitedCells);
                AddNeighbor(currentCell, Direction.Up, cellsOrder, visitedCells);
                AddNeighbor(currentCell, Direction.Left, cellsOrder, visitedCells);
                AddNeighbor(currentCell, Direction.Right, cellsOrder, visitedCells);
            }

            return isExitPath;
        }

        private void AddNeighbor(Cell cell, Direction direction,
            Queue<Cell> cellsOrder, HashSet<Cell> visitedCells)
        {
            Cell nextCell = GoToNextCell(cell, direction);
            bool isInnerCell = nextCell.Row >= 0 || nextCell.Row < labyrinth.GetLength(0) || 
                nextCell.Column >= 0 || nextCell.Column < labyrinth.GetLength(1);
            bool isVisited = visitedCells.Contains(labyrinth[nextCell.Row, nextCell.Column]);
            bool isEmpty = labyrinth[nextCell.Row, nextCell.Column].IsEmpty();

            if (isInnerCell && !isVisited && isEmpty)
            {
                cellsOrder.Enqueue(labyrinth[nextCell.Row, nextCell.Column]);
            }
        }

        public bool TryMove(Cell cell, Direction direction)
        {
            Cell nextCell = GoToNextCell(cell, direction);
            bool moveDone = false;
            bool isEmpty = labyrinth[nextCell.Row, nextCell.Column].IsEmpty();
            if (isEmpty)
            {
                moveDone = true;
                this.CurrentCell = nextCell;
                this.labyrinth[nextCell.Row, nextCell.Column] = this.CurrentCell;
                this.labyrinth[cell.Row, cell.Column] = new Cell(cell.Row, cell.Column, 0);
            }

            return moveDone;
        }

        private Cell GoToNextCell(Cell cell, Direction direction)
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

        private bool ExitFound(Cell cell)
        {
            bool exitFound = false;
            bool rowBorder = cell.Row == LabyrinthEngine.LABYRINTH_SIZE - 1 || cell.Row == 0;
            bool columnBorder = cell.Column == LabyrinthEngine.LABYRINTH_SIZE - 1 || cell.Column == 0;
            if (rowBorder || columnBorder)
            {
                exitFound = true;
            }

            return exitFound;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < LabyrinthEngine.LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < LabyrinthEngine.LABYRINTH_SIZE; column++)
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
