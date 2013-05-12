using System;

namespace Labyrinth
{
    internal struct Message
    {
        public const string InvalidMove = "Invalid move!";
        public const string Welcome = "Welcome to \"Labyrinth\" game. " +
            "Please try to escape. \n" +
            "Use 'top' to view the top scoreboard, 'restart' \nto start a new game and 'exit' to quit the game.";
        public const string EnterMove = "Enter your move (L=left, R-right, U=up, D=down): ";
        public const string EnterNameForScoreBoard = "\nPlease enter your name for the top scoreboard: ";
        public const string ScoreBoardEmpty = "The scoreboard is empty.";
        public const string InvalidCommand = "Invalid command!";
        public const string GoodBye = "Goodbye!";
        public const string Win = "Congratulations! You escaped in {0} moves.";
    }
}