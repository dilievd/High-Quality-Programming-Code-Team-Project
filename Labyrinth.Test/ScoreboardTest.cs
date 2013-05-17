using System;
using System.Text;
using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Test
{
    /// <summary>
    /// This is a test class for ScoreboardTest and is intended
    /// to contain all ScoreboardTest Unit Tests
    /// </summary>
    [TestClass]
    public class ScoreboardTest
    {
        [TestMethod]
        public void ToStringWithNoPlayers()
        {
            Scoreboard.Clear();
            Scoreboard scoreboard = Scoreboard.Instance;
            string result = scoreboard.ToString();
            Assert.AreEqual("The scoreboard is empty.", result);
        }

        [TestMethod]
        public void ToStringWithOnePlayer()
        {
            Scoreboard.Clear();
            Scoreboard scoreboard = Scoreboard.Instance;
            Player player = new Player("Bai Ivan", 5);
            scoreboard.AddPlayer(player);
            StringBuilder resultList = new StringBuilder();
            resultList.AppendLine("Scoreboard:");
            string formatPlayer = string.Format("1. {0} --> {1} moves", player.Name, player.MovesCount);
            resultList.AppendLine(formatPlayer);
            string result = scoreboard.ToString();

            Assert.AreEqual(resultList.ToString(), result);
        }

        [TestMethod]
        public void ToStringWithTwoPlayers()
        {
            Scoreboard.Clear();
            Scoreboard scoreboard = Scoreboard.Instance;
            Player player1 = new Player("Bai Ivan", 5);
            Player player2 = new Player("Bai Marin", 3);
            scoreboard.AddPlayer(player1);
            scoreboard.AddPlayer(player2);
            string result = scoreboard.ToString();
            StringBuilder resultList = new StringBuilder();
            resultList.AppendLine("Scoreboard:");
            resultList.AppendLine("1. Bai Marin --> 3 moves");
            resultList.AppendLine("2. Bai Ivan --> 5 moves");
            string resultListToString = resultList.ToString();

            Assert.AreEqual(resultListToString, result);
        }

        [TestMethod]
        public void IsTopResultWhenResultsAreLessThan5()
        {
            Scoreboard.Clear();
            Scoreboard scoreboard = Scoreboard.Instance;
            Player player1 = new Player("Jane", 4);
            scoreboard.AddPlayer(player1);
            bool result = scoreboard.IsTopResult(5);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsTopResultWithBetterResult()
        {
            Scoreboard.Clear();
            Scoreboard scoreboard = Scoreboard.Instance;
            Player player1 = new Player("Jane", 4);
            Player player2 = new Player("Peter", 3);
            Player player3 = new Player("Sam", 7);
            Player player4 = new Player("Peter", 8);
            Player player5 = new Player("Sara", 8);
            scoreboard.AddPlayer(player1);
            scoreboard.AddPlayer(player2);
            scoreboard.AddPlayer(player3);
            scoreboard.AddPlayer(player4);
            scoreboard.AddPlayer(player5);

            bool result = scoreboard.IsTopResult(6);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsTopResultWithWorstResult()
        {
            Scoreboard.Clear();
            Scoreboard scoreboard = Scoreboard.Instance;
            Player player1 = new Player("Jane", 4);
            Player player2 = new Player("Peter", 3);
            Player player3 = new Player("Sam", 7);
            Player player4 = new Player("Peter", 8);
            Player player5 = new Player("Sara", 8);
            scoreboard.AddPlayer(player1);
            scoreboard.AddPlayer(player2);
            scoreboard.AddPlayer(player3);
            scoreboard.AddPlayer(player4);
            scoreboard.AddPlayer(player5);

            bool result = scoreboard.IsTopResult(9);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AddPlayerWhenScoreboardHas5Results()
        {
            Scoreboard.Clear();
            Scoreboard scoreboard = Scoreboard.Instance;
            Player player1 = new Player("Jane", 4);
            Player player2 = new Player("Peter", 3);
            Player player3 = new Player("Sam", 7);
            Player player4 = new Player("Pit", 8);
            Player player5 = new Player("Sara", 6);
            scoreboard.AddPlayer(player1);
            scoreboard.AddPlayer(player2);
            scoreboard.AddPlayer(player3);
            scoreboard.AddPlayer(player4);
            scoreboard.AddPlayer(player5);
            Player player6 = new Player("Jim", 5);
            scoreboard.AddPlayer(player6);
            StringBuilder resultList = new StringBuilder();
            resultList.AppendLine("Scoreboard:");
            string formatPlayer1 = string.Format("1. {0} --> {1} moves", player2.Name, player2.MovesCount);
            string formatPlayer2 = string.Format("2. {0} --> {1} moves", player1.Name, player1.MovesCount);
            string formatPlayer3 = string.Format("3. {0} --> {1} moves", player6.Name, player6.MovesCount);
            string formatPlayer4 = string.Format("4. {0} --> {1} moves", player5.Name, player5.MovesCount);
            string formatPlayer5 = string.Format("5. {0} --> {1} moves", player3.Name, player3.MovesCount);
            resultList.AppendLine(formatPlayer1);
            resultList.AppendLine(formatPlayer2);
            resultList.AppendLine(formatPlayer3);
            resultList.AppendLine(formatPlayer4);
            resultList.AppendLine(formatPlayer5);

            Assert.AreEqual(resultList.ToString(), scoreboard.ToString());
        }
    }
}