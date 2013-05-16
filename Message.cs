using System;

namespace Labyrinth
{
    /// <summary>
    /// Represent messages printed for the user
    /// </summary>
    public struct Message
    {
        public const string INVALID_MOVE = "Invalid move!";
        public const string WELCOME = "Welcome to \"Labyrinth\" game. Please try to escape." +
            "\nUse 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.";

        public const string ENTER_MOVE = "Enter your move (L=left, R-right, U=up, D=down): ";
        public const string ENTER_NAME_FOR_SCOREBOARD = "Please enter your name for the top scoreboard: ";
        public const string SCOREBOARD_EMPTY = "The scoreboard is empty.";
        public const string INVALID_COMMAND = "Invalid command!";
        public const string GOOD_BYE = "Goodbye!";
        public const string WIN = "Congratulations! You escaped in {0} moves.";
    }
}