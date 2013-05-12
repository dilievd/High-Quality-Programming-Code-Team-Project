using System;

namespace Labyrinth
{
    public class Game
    {
        private static Scoreboard scoreboard = new Scoreboard();

        public Game()
        {
        }

        public void Play()
        {
            ConsoleIO.Print(Message.Welcome, true);
            LabyrinthEngine labyrinth = new LabyrinthEngine();
            int movesCount = 0;
            string input = "";

            while (!labyrinth.ExitFound(labyrinth.CurrentCell) && input != "restart")
            {
                ConsoleIO.Print(labyrinth.ToString(), false);
                //labyrinth.PrintLabyrinth();
                input = ConsoleIO.GetInput();
                ProccessInput(input, labyrinth, ref movesCount, scoreboard);
            }

            if (input != "restart")
            {
                ConsoleIO.Print(Message.Win, false, movesCount.ToString());

                if (scoreboard.IsTopResult(movesCount))
                {
                    ConsoleIO.Print(Message.EnterNameForScoreBoard, false);
                    string name = Console.ReadLine();
                    Player currentPlayer = new Player(name, movesCount);
                    scoreboard.AddPlayer(currentPlayer);
                }

                ConsoleIO.Print(scoreboard.ToString(), true);
            }
        }

        private void ProccessInput(string input, LabyrinthEngine labyrinth,
            ref int movesCount, Scoreboard scoreboard)
        {
            string inputToLower = input.ToLower();
            bool moveDone = false;
            bool command = false;
            var invalidCommand = false;
            switch (inputToLower)
            {
                case "u":
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Up);
                    break;
                case "d":
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Down);
                    break;
                case "l":
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Left);
                    break;
                case "r":
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Right);
                    break;
                case "top":
                    command = true;
                    ConsoleIO.Print(scoreboard.ToString(), true);
                    break;
                case "exit":
                    command = true;
                    ConsoleIO.Print(Message.GoodBye, true);
                    Environment.Exit(0);
                    break;
                case "restart":
                    command = true;
                    break;
                default:
                    invalidCommand = true;
                    ConsoleIO.Print(Message.InvalidCommand, true);
                    break;
            }

            if (moveDone)
            {
                movesCount++;
            }

            if (!moveDone && !command && !invalidCommand)
            {
                ConsoleIO.Print(Message.InvalidMove, true);
            }
        }
    }
}
