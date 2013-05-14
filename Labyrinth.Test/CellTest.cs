﻿using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Labyrinth.Test
{
    /// <summary>
    /// This is a test class for Cell and is intended
    /// to contain all Cell Unit Tests
    /// </summary>
    [TestClass()]
    public class CellTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CellWithNegativeRowNumber()
        {
            int row = -1;
            int col = 1;
            char symbol = '*';
            Cell cell = new Cell(row, col, symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CellWithNegativeColumnNumber()
        {
            int row = 1;
            int col = -1;
            char symbol = '*';
            Cell cell = new Cell(row, col, symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CellWithBiggerRowNumberBiggerThanSize()
        {
            int row = 7;
            int col = 1;
            char symbol = '*';
            Cell cell = new Cell(row, col, symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CellWithColumnNumberBiggerThanSize()
        {
            int row = 1;
            int col = 7;
            char symbol = '*';
            Cell cell = new Cell(row, col, symbol);
        }

        [TestMethod]
        public void CellWithRowAndColumnNumberEqualToZero()
        {
            int row = 0;
            int col = 0;
            char symbol = '*';
            Cell cell = new Cell(row, col, symbol);

            int resultRow = cell.Row;
            Assert.AreEqual(row, resultRow);

            int resultCol = cell.Column;
            Assert.AreEqual(row, resultCol);
        }

        [TestMethod]
        public void CellWithRowAndColumnNumberEqualToSize()
        {
            int row = 6;
            int col = 6;
            char symbol = '*';
            Cell cell = new Cell(row, col, symbol);

            int resultRow = cell.Row;
            Assert.AreEqual(row, resultRow);

            int resultCol = cell.Column;
            Assert.AreEqual(row, resultCol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CellWithWhitespaceSymbol()
        {
            int row = 3;
            int col = 3;
            char symbol = ' ';
            Cell cell = new Cell(row, col, symbol);
        }

        [TestMethod]
        public void CellGetSymbol()
        {
            int row = 0;
            int col = 0;
            char symbol = '*';
            Cell cell = new Cell(row, col, symbol);

            char resultSymbol = cell.Symbol;
            Assert.AreEqual(symbol, resultSymbol);
        }
    }
}
