﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    /// <summary>
    /// Represent the labyrinth engine for the game
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Represent number of rows and columns of the labyrinth
        /// </summary>
        public const int LABYRINTH_SIZE = 7;
        public const char EMPTY_CELL = '-';
        public const char WALL_CELL = 'X';
        public const char PLAYER = '*';
        private const char VISITED = 'v';
        private readonly int StartRow = LABYRINTH_SIZE / 2;
        private readonly int StartColumn = LABYRINTH_SIZE / 2;
        private Cell[,] labyrinth = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];
        private Cell[,] dummyLabyrinth = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];
        private Random rand = new Random();      
        
        /// <summary>
        /// Create engine
        /// </summary>
        public Engine()
        {
            this.CurrentCell = new Cell(this.StartRow, this.StartColumn, PLAYER);
            this.GenerateLabyrinth();
        }

        /// <summary>
        /// Represent the the cell in the labyrinth, where is the player
        /// </summary>
        public Cell CurrentCell { get; private set; }

        protected Cell[,] Labyrinth
        {
            get { return this.labyrinth; }
            set { this.labyrinth = value; }
        }

        protected Cell[,] DummyLabyrinth
        {
            get { return this.dummyLabyrinth; }
            set { this.dummyLabyrinth = value; }
        }

        /// <summary>
        /// Check if given move is possible
        /// </summary>
        /// <param name="cell">Cell from which start the move</param>
        /// <param name="direction">Direction of the move</param>
        /// <returns>Is or is not done the move</returns>
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

        /// <summary>
        /// Check is the player escaped from the labyrinth
        /// </summary>
        /// <param name="cell">Cell where is the player</param>
        /// <returns>Is the player or is not escaped from the labyrinth</returns>
        public bool ExitFound(Cell cell)
        {
            bool exitFound = false;
            bool rowBorder = cell.Row == LABYRINTH_SIZE - 1 || cell.Row == 0;
            bool columnBorder = cell.Column == LABYRINTH_SIZE - 1 || cell.Column == 0;
            if (rowBorder || columnBorder)
            {
                exitFound = true;
            }

            return exitFound;
        }

        /// <summary>
        /// Create string representation of the labyrinth
        /// </summary>
        /// <returns>String representation of the labyrinth</returns>
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

        /// <summary>
        /// Creae labyrinth by initializing its cells
        /// </summary>
        protected virtual void CreateLabyrinth()
        {
            for (int row = 0; row < LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < LABYRINTH_SIZE; column++)
                {
                    int randomValue = this.rand.Next(0, 2);
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

            this.labyrinth[this.StartRow, this.StartColumn] = new Cell(this.StartRow, this.StartColumn, PLAYER);
            this.dummyLabyrinth[this.StartRow, this.StartColumn] = new Cell(this.StartRow, this.StartColumn, PLAYER);
        }

        /// <summary>
        /// Generate new labyrinth till there is no way to escape from the labyrinth
        /// </summary>
        private void GenerateLabyrinth()
        {
            bool labyrinthHasExit = false;
            do
            {
                this.CreateLabyrinth();
                labyrinthHasExit = this.HasExit(this.CurrentCell);
            }
            while (!labyrinthHasExit);
        }

        /// <summary>
        /// Check is there a way to escape from the labyrinth
        /// </summary>
        /// <param name="cell">Cell from which strart the way</param>
        private bool HasExit(Cell cell)
        {
            char currentSymbol = cell.Symbol;
            this.dummyLabyrinth[cell.Row, cell.Column].Symbol = VISITED;
            bool isExitFound = false;

            if (currentSymbol == EMPTY_CELL || currentSymbol == PLAYER)
            {
                isExitFound = this.ExitFound(cell);
                if (!isExitFound)
                {
                    isExitFound =
                        this.HasExit(this.dummyLabyrinth[cell.Row, cell.Column - 1]) ||
                        this.HasExit(this.dummyLabyrinth[cell.Row, cell.Column + 1]) ||
                        this.HasExit(this.dummyLabyrinth[cell.Row + 1, cell.Column]) ||
                        this.HasExit(this.dummyLabyrinth[cell.Row - 1, cell.Column]);
                }
            }

            return isExitFound;
        }
    }
}