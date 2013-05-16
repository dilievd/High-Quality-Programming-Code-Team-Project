using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Labyrinth.Test
{
    /// <summary>
    /// This is a test class for Game and is intended
    /// to contain all Game Unit Tests
    /// </summary>
    [TestClass()]
    public class GameTest
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GameWithNullScoreboard()
        {
            Game game = new Game(null);
        }

        [TestMethod]
        public void GameScoreboard()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            Game game = new Game(scoreboard);
        }

        [TestMethod]
        public void GameProcessMoveUp()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedGame game = new DerivedGame(scoreboard, matrix);
            bool result = game.DerivedProcessMove("U");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GameProcessMoveRight()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedGame game = new DerivedGame(scoreboard, matrix);
            bool result = game.DerivedProcessMove("R");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GameProcessMoveLeft()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedGame game = new DerivedGame(scoreboard, matrix);
            bool result = game.DerivedProcessMove("L");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GameProcessMoveDown()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedGame game = new DerivedGame(scoreboard, matrix);
            bool result = game.DerivedProcessMove("D");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GameProcessMoveInvalid()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedGame game = new DerivedGame(scoreboard, matrix);
            bool result = game.DerivedProcessMove("ADGHNBSDFCQAC");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GameProcessMoveCommand()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedGame game = new DerivedGame(scoreboard, matrix);
            bool result = game.DerivedProcessMove("TOP");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GameProcessCommandIsValidMove()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedGame game = new DerivedGame(scoreboard, matrix);
            bool result = game.DerivedProcessCommand("D", true);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GameProcessCommandTop()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedGame game = new DerivedGame(scoreboard, matrix);
            bool result = game.DerivedProcessCommand("TOP", false);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GameProcessCommandRestart()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedGame game = new DerivedGame(scoreboard, matrix);
            bool result = game.DerivedProcessCommand("RESTART", false);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GameProcessCommandExit()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedGame game = new DerivedGame(scoreboard, matrix);
            bool result = game.DerivedProcessCommand("EXIT", false);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GameProcessCommandInvalid()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            int[,] matrix = new int[Engine.LABYRINTH_SIZE, Engine.LABYRINTH_SIZE];
            DerivedGame game = new DerivedGame(scoreboard, matrix);
            bool result = game.DerivedProcessCommand("ASFGFHNDFVA", false);
            Assert.IsFalse(result);
        }
    }
}
