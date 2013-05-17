using System;
using System.Text;
using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Test
{
    /// <summary>
    /// This is a test class for EngineTest and is intended
    /// to contain all EngineTest Unit Tests
    /// </summary>
    [TestClass]
    public class EngineTest
    {
        [TestMethod]
        public void InitializeLabyrinthZeroMatrix()
        {
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedEngine labyrinth = new DerivedEngine(matrix);

            Cell[,] cellMatrix =
                new Cell[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];

            for (int row = 0; row < Engine.LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < Engine.LABYRINTH_SIZE; column++)
                {
                    cellMatrix[row, column] = new Cell(row, column, Engine.EMPTY_CELL);
                }
            }

            cellMatrix[labyrinth.CurrentCell.Row, labyrinth.CurrentCell.Column] =
                new Cell(labyrinth.CurrentCell.Row, labyrinth.CurrentCell.Column, Engine.PLAYER);

            Assert.AreEqual(labyrinth.ToString(), LabyrinthToString(cellMatrix));
        }

        [TestMethod]
        public void TryMoveOnEmptyCell()
        {
            var startRow = Engine.LABYRINTH_SIZE / 2;
            var startCol = Engine.LABYRINTH_SIZE / 2;

            Cell cellOne = new Cell(startRow - 1, startCol, Engine.EMPTY_CELL);
            Cell cellTwo = new Cell(startRow, startCol - 2, Engine.EMPTY_CELL);
            Cell cellThree = new Cell(startRow, startCol - 3, Engine.EMPTY_CELL);

            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            matrix = this.CreateMatrixWithExit(cellOne, cellTwo, cellThree);
            DerivedEngine labyrinth = new DerivedEngine(matrix);

            bool moveSuccessful = labyrinth.TryMove(labyrinth.CurrentCell, Direction.Up);

            Assert.AreEqual(true, moveSuccessful);
        }

        [TestMethod]
        public void TryMoveOnNonEmptyCell()
        {
            int[,] matrix = this.CreateMatrixWithExit();
            DerivedEngine labyrinth = new DerivedEngine(matrix);

            bool moveSuccessful = labyrinth.TryMove(labyrinth.CurrentCell, Direction.Left);

            Assert.AreEqual(false, moveSuccessful);
        }

        private static string LabyrinthToString(Cell[,] matrix)
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < Engine.LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < Engine.LABYRINTH_SIZE; column++)
                {
                    Cell cell = matrix[row, column];
                    result.Append(cell.Symbol + " ");
                }

                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

        private int[,] CreateMatrixWithExit(params Cell[] exitPath)
        {
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];

            for (int row = 0; row < Engine.LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < Engine.LABYRINTH_SIZE; column++)
                {
                    matrix[row, column] = 1;
                }
            }

            foreach (var cell in exitPath)
            {
                int cellRow = cell.Row;
                int cellCol = cell.Column;
                matrix[cellRow, cellCol] = 0;
            }

            return matrix;
        }
    }
}
