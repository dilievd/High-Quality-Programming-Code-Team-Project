using System;

namespace Labyrinth
{
    public class Game
    {
        private Scoreboard scoreboard;
        LabyrinthEngine labyrinth;
        public bool isGameOver;
        int movesCount;

        public Game(Scoreboard scoreboard)
        {
            this.isGameOver = false;
            this.movesCount = 0;
            this.labyrinth = new LabyrinthEngine();
            this.scoreboard = scoreboard;
        }

        public void Play()
        {
            ConsoleIO.Print(Message.Welcome, true);
            string input = string.Empty;

            while (!this.labyrinth.ExitFound(this.labyrinth.CurrentCell) && input != "RESTART")
            {
                ConsoleIO.Print(this.labyrinth.ToString(), false);
                input = ConsoleIO.GetInput().ToUpper();
                this.ProcessInput(input);
            }

            if (input != "RESTART")
            {
                ConsoleIO.Print(Message.Win, false, this.movesCount.ToString());

                if (scoreboard.IsTopResult(movesCount))
                {
                    ConsoleIO.Print(Message.EnterNameForScoreBoard, false);
                    string name = Console.ReadLine();
                    Player currentPlayer = new Player(name, movesCount);
                    scoreboard.AddPlayer(currentPlayer);
                }

                ConsoleIO.Print(scoreboard.ToString(), false);
            }
        }

        private void ProcessInput(string input)
        {
            string inputToUpper = input.ToUpper();
            bool invalidMove = ProcessMove(inputToUpper);
            ProcessCommand(input, invalidMove);
        }

        private bool ProcessMove(string input)
        {
            bool moveDone = false;
            bool validCommand = false;
            if (input == "U")
            {
                moveDone = this.labyrinth.TryMove(this.labyrinth.CurrentCell, Direction.Up);
                validCommand = true;
            }
            else if (input == "D")
            {
                moveDone = this.labyrinth.TryMove(this.labyrinth.CurrentCell, Direction.Down);
                validCommand = true;
            }
            else if (input == "L")
            {
                moveDone = this.labyrinth.TryMove(this.labyrinth.CurrentCell, Direction.Left);
                validCommand = true;
            }
            else if (input == "R")
            {
                moveDone = this.labyrinth.TryMove(this.labyrinth.CurrentCell, Direction.Right);
                validCommand = true;
            }

            if (moveDone)
            {
                this.movesCount++;
            }

            if (!moveDone && validCommand)
            {
                ConsoleIO.Print(Message.InvalidMove, true);
            }

            return !moveDone && validCommand;
        }

        private void ProcessCommand(string input, bool invalidMove)
        {
            bool commandDone = false;
            if (input == "TOP")
            {
                commandDone = true;
                ConsoleIO.Print(this.scoreboard.ToString(), true);
            }
            else if (input == "EXIT")
            {
                commandDone = true;
                ConsoleIO.Print(Message.GoodBye, true);
                this.isGameOver = true;
            }
            else if (input == "RESTART")
            {
                commandDone = true;
            }

            if (!invalidMove && !commandDone)
            {
                ConsoleIO.Print(Message.InvalidCommand, true);
            }
        }
    }
}
