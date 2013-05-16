using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Test
{
    /// <summary>
    /// Summary description for ConsoleIOTest
    /// </summary>
    [TestClass]
    public class ConsoleIOTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConsoleIOPrintNull()
        {
            ConsoleIO.Print(null, false);
        }

        [TestMethod]
        public void ConsoleIOPrintMessageInvalidMove()
        {
            string invalidMove = ConsoleIO.Print(Message.InvalidMove, false);
            Assert.AreEqual(Environment.NewLine.ToString() + "Invalid move!", invalidMove);
        }

        [TestMethod]
        public void ConsoleIOPrintMessageWelcome()
        {
            string welcome = ConsoleIO.Print(Message.Welcome, false);
            Assert.AreEqual(Environment.NewLine.ToString() + 
                "Welcome to \"Labyrinth\" game. Please try to escape." +
                "\nUse 'top' to view the top scoreboard, 'restart' to start a new game" + 
                " and \n'exit' to quit the game.",
            welcome); 
        }

        [TestMethod]
        public void ConsoleIOPrintMessageEnterMove()
        {
            string enterMove = ConsoleIO.Print(Message.EnterMove, true);
            Assert.AreEqual(Environment.NewLine.ToString() + 
                "Enter your move (L=left, R-right, U=up, D=down): " +
                Environment.NewLine.ToString(), enterMove);
        }

        [TestMethod]
        public void ConsoleIOPrintMessageEnterNameForScoreBoard()
        {
            string enterNameForScoreBoard = ConsoleIO.Print(Message.EnterNameForScoreBoard, false);
            Assert.AreEqual(Environment.NewLine.ToString() + 
                "Please enter your name for the top scoreboard: ", enterNameForScoreBoard);
        }

        [TestMethod]
        public void ConsoleIOPrintMessageInvalidCommand()
        {
            string invalidCommand = ConsoleIO.Print(Message.InvalidCommand, true);
            Assert.AreEqual(Environment.NewLine.ToString() +
                "Invalid command!" + Environment.NewLine.ToString(), invalidCommand);    
        }

        [TestMethod]
        public void ConsoleIOPrintMessageGoodBye()
        {
            string goodBye = ConsoleIO.Print(Message.GoodBye, false);
            Assert.AreEqual(Environment.NewLine.ToString() + 
                "Goodbye!", goodBye);
        }

        [TestMethod]
        public void ConsoleIOPrintMessageWin()
        {
            string win = ConsoleIO.Print(Message.Win, false, "5");
            Assert.AreEqual(Environment.NewLine.ToString() + 
                "Congratulations! You escaped in 5 moves.", win);
        }

        [TestMethod]
        public void ConsoleIOPrintMessagescoreBoardEmpty()
        {
            Scoreboard.Clear();
            Scoreboard scoreboard = Scoreboard.Instance;
            string result = ConsoleIO.Print(scoreboard.ToString(), true);
            string expectedMessage = Environment.NewLine.ToString() + 
                Message.ScoreBoardEmpty + Environment.NewLine.ToString();
            Assert.AreEqual(expectedMessage, result);
        }

        [TestMethod]
        public void ConsoleIOPrintScoreboard()
        {
            Scoreboard.Clear();
            Scoreboard scoreboard = Scoreboard.Instance;
            Player player = new Player("Ivan", 5);
            scoreboard.AddPlayer(player);
            string result = ConsoleIO.Print(scoreboard.ToString(), false);
            StringBuilder resultList = new StringBuilder();
            resultList.AppendLine(Environment.NewLine.ToString() + "Scoreboard:");
            resultList.AppendLine("1. Ivan --> 5 moves");

            Assert.AreEqual(resultList.ToString(), result);
        }
    }
}
