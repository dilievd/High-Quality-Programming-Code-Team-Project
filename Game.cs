using System;

namespace Labyrinth
{
    class Game
    {
        public Game(Scoreboard ladder)
        {
            LabyrinthEngine labyrinth = new LabyrinthEngine();
            ConsoleIO.Print(Message.Welcome, true);
            int movesCount = 0;
            string input = "";

            while (!labyrinth.ExitFound(labyrinth.CurrentCell) && input != "restart")
            {
                ConsoleIO.Print(labyrinth.ToString(), true);
                //labyrinth.PrintLabyrinth();
                input = ConsoleIO.GetInput();
                ProccessInput(input, labyrinth, ref movesCount, ladder);
            }

            if (input != "restart")
            {
                ConsoleIO.Print(Message.Win, true, movesCount.ToString()); 
                if (ladder.IsTopResult(movesCount))
                {
                    ConsoleIO.Print(Message.EnterNameForScoreBoard, false);
                    string name = Console.ReadLine();
                    Player currentPlayer = new Player(name, movesCount);
                    ladder.AddPlayer(currentPlayer);
                }
            }
        }

        private void ProccessInput(string input, LabyrinthEngine labyrinth,
            ref int movesCount, Scoreboard ladder)
        {
            string inputToLower = input.ToLower();
            bool moveDone = false;
            bool command = false;
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
                    ConsoleIO.Print(ladder.ToString(), true);
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
                    ConsoleIO.Print(Message.InvalidCommand, true);
                    break;
            }

            if (moveDone)
            {
                movesCount++;
            }

            if (!moveDone && !command)
            {
                ConsoleIO.Print(Message.InvalidMove, true);
            }
        }
    }
}
