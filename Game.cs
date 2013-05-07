using System;

namespace Labyrinth
{
    class Game
    {
        public Game(Random rand, Scoreboard ladder)
        {
            LabyrinthEngine labyrinth = new LabyrinthEngine(rand);
            Message.Welcome();
            int movesCount = 0;
            string input = "";

            while (!IsGameOver(labyrinth) && input != "restart")
            {
                labyrinth.PrintLabyrinth();
                input = PlayerInput.GetInput();
                ProccessInput(input, labyrinth, ref movesCount, ladder);
            }

            if (input != "restart")
            {
                Console.WriteLine("Congratulations! You escaped in {0} moves.",
                    movesCount); // Message.Win(movesCount); // 
                if (ladder.PlayerQualifiesInScoreboard(movesCount))
                {
                    Message.EnterNameForScoreBoard();
                    string name = Console.ReadLine();
                    ladder.AddPlayerInScoreboard(name, movesCount);
                }
            }

            Console.WriteLine();
        }

        private bool IsGameOver(LabyrinthEngine labyrinth)
        {
            bool isGameOver = false;
            int currentRow = labyrinth.CurrentCell.Row;
            int currentCol = labyrinth.CurrentCell.Column;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == LabyrinthEngine.LABYRINTH_SIZE - 1 ||
                currentCol == LabyrinthEngine.LABYRINTH_SIZE - 1)
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        private bool TryMove(string direction, LabyrinthEngine labyrinth)
        {
            bool moveDone = false;
            switch (direction)
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
                default:
                    Message.InvalidMove();
                    break;
            }

            if (moveDone == false)
            {
                Message.InvalidMove();
            }

            return moveDone;
        }

        private void ProccessInput(string input, LabyrinthEngine labyrinth,
            ref int movesCount, Scoreboard ladder)
        {
            string inputToLower = input.ToLower();
            switch (inputToLower)
            {
                case "u":
                case "d":
                case "l":
                case "r":
                    //fallthrough
                    bool moveDone =
                        TryMove(inputToLower, labyrinth);
                    if (moveDone == true)
                    {
                        movesCount++;
                    }

                    break;
                case "top":
                    ladder.PrintScoreBoard();
                    break;
                case "exit":
                    Message.GoodBye();
                    Environment.Exit(0);
                    break;
                case "restart":
                    break;
                default:
                    Message.InvalidCommand();
                    break;
            }
        }
    }
}
