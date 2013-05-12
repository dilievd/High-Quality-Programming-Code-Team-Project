using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public class LabyrinthEngine
    {
        public const int LABYRINTH_SIZE = 7;
        private readonly int startRow = LABYRINTH_SIZE / 2;
        private readonly int startColumn = LABYRINTH_SIZE / 2;
        private const char EMPTY_CELL = '-';
        private const char WALL_CELL = 'X';
        private const char PLAYER = '*';
        private const char VISITED = 'v';

        Random rand = new Random();

        private Cell[,] labyrinth = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];
        private Cell[,] dummyLabyrint = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];
        private bool exitFound = false;

        public Cell CurrentCell { get; private set; }

        public LabyrinthEngine()
        {
            GenerateLabyrinth();
            CurrentCell = labyrinth[this.startRow, this.startColumn];
        }

        private void GenerateLabyrinth()
        {    
            do
            {
                CreateLabyrinth();
            } while (!exitFound);
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
                        this.dummyLabyrint[row, column] = new Cell(row, column, EMPTY_CELL);
                    }
                    else
                    {
                        this.labyrinth[row, column] = new Cell(row, column, WALL_CELL);
                        this.dummyLabyrint[row, column] = new Cell(row, column, WALL_CELL);
                    }
                }
            }

            this.labyrinth[this.startRow, this.startColumn] = new Cell(this.startRow, this.startColumn, PLAYER);
            this.dummyLabyrint[this.startRow, this.startColumn] = new Cell(this.startRow, this.startColumn, PLAYER);

            HasExit(this.startRow, startColumn);
        }        

        public bool TryMove(Cell cell, Direction direction)
        {
            Cell nextCell = GoToNextCell(cell, direction);
            bool moveDone = false;
            bool isEmpty = labyrinth[nextCell.Row, nextCell.Column].Symbol == EMPTY_CELL;
            if (isEmpty)
            {
                moveDone = true;
                this.CurrentCell = nextCell;
                this.labyrinth[nextCell.Row, nextCell.Column] = this.CurrentCell;
                this.labyrinth[cell.Row, cell.Column] = new Cell(cell.Row, cell.Column, EMPTY_CELL);
            }

            return moveDone;
        }

        private Cell GoToNextCell(Cell cell, Direction direction)
        {
            Cell nextCell = new Cell(cell.Row + direction.X, cell.Column+direction.Y, cell.Symbol);
          
            return nextCell;
        }

        private void HasExit(int row, int col)
        {
            char currentSymbol = dummyLabyrint[row, col].Symbol;
            dummyLabyrint[row, col] = new Cell(row, col, VISITED);

            if (currentSymbol == EMPTY_CELL ||
                currentSymbol == PLAYER)
            {

                if (IsAtLabSide(row, col))
                {
                    exitFound = true;
                    return;
                }

                if (!exitFound)
                {
                    HasExit(row, col - 1); //left
                    HasExit(row - 1, col); // up
                    HasExit(row, col + 1); // right                   
                    HasExit(row + 1, col); // down
                }
            }
        }

        private bool IsAtLabSide(int row, int col)
        {
            if (row == 0 ||
                col == 0 ||
                row == LabyrinthEngine.LABYRINTH_SIZE - 1 ||
                col == LabyrinthEngine.LABYRINTH_SIZE - 1)
            {
                return true;
            }

            return false;
        }

        public bool ExitFound(Cell cell)
        {
            bool exitFound = false;
            bool rowBorder = (cell.Row == LabyrinthEngine.LABYRINTH_SIZE - 1 || cell.Row == 0);
            bool columnBorder = (cell.Column == LabyrinthEngine.LABYRINTH_SIZE - 1 || cell.Column == 0);
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
