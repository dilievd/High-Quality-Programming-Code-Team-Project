using System;

namespace Labyrinth
{
    internal struct Message
    {
        public const string InvalidMove = "Invalid move!";
        public const string Welcome = "Welcome to \"Labyrinth\" game. \n" +
            "Please try to escape. \n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.\n";
        public const string EnterMove = "\nEnter your move (L=left, R-right, U=up, D=down): ";
        public const string EnterNameForScoreBoard = "\nPlease enter your name for the top scoreboard: ";
        public const string ScoreBoardEmpty = "The scoreboard is empty.";
        public const string InvalidCommand = "\nInvalid command!\n";
        public const string GoodBye = "Good Bye";
        public const string Win = "Congratulations! You escaped in {0} moves.";
    }
}