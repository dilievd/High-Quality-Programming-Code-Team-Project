using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Test
{
    /// <summary>
    /// This is a test class for Player and is intended
    /// to contain all Player Unit Tests
    /// </summary>
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerWithNullName()
        {
            string name = null;
            int movesCount = Engine.LABYRINTH_SIZE / 2;
            Player player = new Player(name, movesCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerWithEmptyName()
        {
            string name = string.Empty;
            int movesCount = Engine.LABYRINTH_SIZE / 2;
            Player player = new Player(name, movesCount);
        }

        [TestMethod]
        public void PlayerWithValidName()
        {
            string name = "Dexter Morgan";
            int movesCount = Engine.LABYRINTH_SIZE / 2;
            Player player = new Player(name, movesCount);

            string resultName = player.Name;
            Assert.AreEqual(name, resultName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerWithZeroMovesCount()
        {
            string name = "Dexter Morgan";
            int movesCount = 0;
            Player player = new Player(name, movesCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerWithNegativeMovesCount()
        {
            string name = "Dexter Morgan";
            int movesCount = -1;
            Player player = new Player(name, movesCount);
        }

        [TestMethod]
        public void PlayerWithValidMovesCount()
        {
            string name = "Dexter Morgan";
            int movesCount = Engine.LABYRINTH_SIZE / 2;
            Player player = new Player(name, movesCount);

            int resultMovesCount = player.MovesCount;
            Assert.AreEqual(movesCount, resultMovesCount);
        }

        [TestMethod]
        public void CompareToPlayerWithMoreMovesCount()
        {
            string name1 = "Dexter Morgan";
            int movesCount1 = Engine.LABYRINTH_SIZE / 2;
            Player player1 = new Player(name1, movesCount1);

            string name2 = "Deborah Morgan";
            int movesCount2 = (Engine.LABYRINTH_SIZE / 2) + 1;
            Player player2 = new Player(name2, movesCount2);

            int result = player1.CompareTo(player2);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CompareToPlayerWithLessMovesCount()
        {
            string name1 = "Dexter Morgan";
            int movesCount1 = (Engine.LABYRINTH_SIZE / 2) + 1;
            Player player1 = new Player(name1, movesCount1);

            string name2 = "Deborah Morgan";
            int movesCount2 = Engine.LABYRINTH_SIZE / 2;
            Player player2 = new Player(name2, movesCount2);

            int result = player1.CompareTo(player2);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CompareToPlayerWithSameMovesCount()
        {
            string name1 = "Dexter Morgan";
            int movesCount1 = Engine.LABYRINTH_SIZE / 2;
            Player player1 = new Player(name1, movesCount1);

            string name2 = "Deborah Morgan";
            int movesCount2 = Engine.LABYRINTH_SIZE / 2;
            Player player2 = new Player(name2, movesCount2);

            int result = player1.CompareTo(player2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareToPlayerWithSameNamesAndMoves()
        {
            string name1 = "Dexter Morgan";
            int movesCount1 = Engine.LABYRINTH_SIZE / 2;
            Player player1 = new Player(name1, movesCount1);

            string name2 = "Dexter Morgan";
            int movesCount2 = Engine.LABYRINTH_SIZE / 2;
            Player player2 = new Player(name2, movesCount2);

            int result = player1.CompareTo(player2);
            Assert.AreEqual(0, result);
        }
    }
}
