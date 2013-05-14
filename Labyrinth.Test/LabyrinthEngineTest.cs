﻿using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Labyrinth.Test
{
    
    
    /// <summary>
    ///This is a test class for LabyrinthEngineTest and is intended
    ///to contain all LabyrinthEngineTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LabyrinthEngineTest
    {
        private static string LabyrinthToString(Cell[,] matrix)
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < LabyrinthEngine.LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < LabyrinthEngine.LABYRINTH_SIZE; column++)
                {
                    Cell cell = matrix[row, column];
                    result.Append(cell.Symbol + " ");
                }

                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

        [TestMethod]        
        public void InitializeLabyrinthZeroMatrix() 
        {
            int[,] matrix = new int[LabyrinthEngine.LABYRINTH_SIZE, LabyrinthEngine.LABYRINTH_SIZE];
            DerivedLabyrinthEngine labyrinth = new DerivedLabyrinthEngine(matrix);

            Cell[,] cellMatrix =
                new Cell[LabyrinthEngine.LABYRINTH_SIZE, LabyrinthEngine.LABYRINTH_SIZE];

            for (int row = 0; row < LabyrinthEngine.LABYRINTH_SIZE; row++)
            {
                for (int column = 0; column < LabyrinthEngine.LABYRINTH_SIZE; column++)
                {
                    cellMatrix[row, column] = new Cell(row, column, LabyrinthEngine.EMPTY_CELL);
                }
            }

            cellMatrix[labyrinth.CurrentCell.Row, labyrinth.CurrentCell.Column] =
                new Cell(labyrinth.CurrentCell.Row, labyrinth.CurrentCell.Column, LabyrinthEngine.PLAYER);

            Assert.AreEqual(labyrinth.ToString(), LabyrinthToString(cellMatrix));
        }
        #region
        //[TestMethod]
        //public void TryMoveTest()
        //{
        //    LabyrinthEngine target = new LabyrinthEngine(); // TODO: Initialize to an appropriate value
        //    Cell cell = null; // TODO: Initialize to an appropriate value
        //    Direction direction = null; // TODO: Initialize to an appropriate value
        //    bool expected = false; // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.TryMove(cell, direction);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[TestMethod()]
        //public void ToStringTest()
        //{
        //    LabyrinthEngine target = new LabyrinthEngine(); // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = target.ToString();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for ExitFound
        /////</summary>
        //[TestMethod()]
        //public void ExitFoundTest()
        //{
        //    LabyrinthEngine target = new LabyrinthEngine(); // TODO: Initialize to an appropriate value
        //    Cell cell = null; // TODO: Initialize to an appropriate value
        //    bool expected = false; // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.ExitFound(cell);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        /////// <summary>
        ///////A test for LabyrinthEngine Constructor
        ///////</summary>
        ////[TestMethod()]
        ////public void LabyrinthEngineConstructorTest()
        ////{
        ////    Cell[,] labyrinth = null; // TODO: Initialize to an appropriate value
        ////    LabyrinthEngine target = new LabyrinthEngine(labyrinth);
        ////    Assert.Inconclusive("TODO: Implement code to verify target");
        ////}

        ///// <summary>
        /////A test for LabyrinthEngine Constructor
        /////</summary>
        //[TestMethod()]
        //public void LabyrinthEngineConstructorTest1()
        //{
        //    LabyrinthEngine target = new LabyrinthEngine();
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}
        #endregion
    }
}
