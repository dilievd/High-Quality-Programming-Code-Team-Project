using System;

namespace Labyrinth
{
    internal static class Message
    {
        private const string InvalidMoveMsg = "Invalid move!";
        private const string InvalidCommandMsg = "\nInvalid command!\n";
        private const string ScoreBoardEmptyMsg = "The scoreboard is empty.";
        private const string EnterNameForScoreBoardMsg = "\nPlease enter your name for the top scoreboard: ";
        private const string GoodByeMsg = "Good Bye";
        private const string EnterMoveMsg = "\nEnter your move (L=left, R-right, U=up, D=down): ";
        private const string WelcomeMsg = "Welcome to \"Labyrinth\" game. \n" +
            "Please try to escape. \n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.\n";

        public static void InvalidMove()
        {
            Console.WriteLine(InvalidMoveMsg);
        }

        public static void InvalidCommand()
        {
            Console.WriteLine(InvalidCommandMsg);
        }

        public static void Welcome()
        {
            Console.WriteLine(WelcomeMsg);
        }

        public static void ScoreboardEmpty()
        {
            Console.WriteLine(ScoreBoardEmptyMsg);
        }

        public static void EnterMove()
        {
            Console.Write(EnterMoveMsg);
        }

        public static void Win(int moves)
        {
            Console.Write("Congratulations! You escaped in {0} moves.\n", moves);
        }

        public static void EnterNameForScoreBoard()
        {
            Console.WriteLine(EnterNameForScoreBoardMsg);
        }

        public static void GoodBye()
        {
            Console.WriteLine(GoodByeMsg);
        }
    }
}