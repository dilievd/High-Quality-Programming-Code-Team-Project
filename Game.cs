using System;

namespace Labyrinth
{
    public class Game
    {
        private Scoreboard scoreboard;
        private LabyrinthEngine labyrinth;
        private int movesCount;

        public Game(Scoreboard scoreboard)
        {
            if (scoreboard == null)
            {
                throw new ArgumentNullException(
                    "Invalid input! Scoreboard cannot be null.");
            }

            this.IsExit = false;
            this.IsRestart = false;
            this.movesCount = 0;
            this.labyrinth = new LabyrinthEngine();
            this.scoreboard = scoreboard;
        }

        /// <summary>
        /// Show is or is not entered EXIT command
        /// </summary>
        public bool IsExit { get; private set; }

        private bool IsRestart { get; set; }

        /// <summary>
        /// Run the game
        /// </summary>
        public void Play()
        {
            ConsoleIO.Print(Message.Welcome, true);
            string input = string.Empty;

            while (!this.labyrinth.ExitFound(this.labyrinth.CurrentCell) && !this.IsRestart && !this.IsExit)
            {
                ConsoleIO.Print(this.labyrinth.ToString(), false);
                input = ConsoleIO.GetInput(Message.EnterMove).ToUpper();
                this.ProcessInput(input);
            }

            if (!this.IsRestart && !this.IsExit)
            {
                ConsoleIO.Print(Message.Win, false, this.movesCount.ToString());

                if (this.scoreboard.IsTopResult(this.movesCount))
                {
                    string name = ConsoleIO.GetInput(Message.EnterNameForScoreBoard);
                    Player currentPlayer = new Player(name, this.movesCount);
                    this.scoreboard.AddPlayer(currentPlayer);
                }

                ConsoleIO.Print(this.scoreboard.ToString(), false);
            }
        }

        /// <summary>
        /// Execute the entered input from the console
        /// </summary>
        /// <param name="input">Entered input</param>
        private void ProcessInput(string input)
        {
            string inputToUpper = input.ToUpper();
            bool isMoveCommand = ProcessMove(inputToUpper);
            ProcessCommand(input, isMoveCommand);
        }

        /// <summary>
        /// Execute the input if it is a command for move
        /// </summary>
        /// <param name="input">Command</param>
        /// <returns>Is or is not a command for move</returns>
        private bool ProcessMove(string input)
        {
            bool isMoveDone = false;
            bool isMoveCommand = false;
            if (input == "U")
            {
                isMoveDone = this.labyrinth.TryMove(this.labyrinth.CurrentCell, Direction.Up);
                isMoveCommand = true;
            }
            else if (input == "D")
            {
                isMoveDone = this.labyrinth.TryMove(this.labyrinth.CurrentCell, Direction.Down);
                isMoveCommand = true;
            }
            else if (input == "L")
            {
                isMoveDone = this.labyrinth.TryMove(this.labyrinth.CurrentCell, Direction.Left);
                isMoveCommand = true;
            }
            else if (input == "R")
            {
                isMoveDone = this.labyrinth.TryMove(this.labyrinth.CurrentCell, Direction.Right);
                isMoveCommand = true;
            }

            if (isMoveDone)
            {
                this.movesCount++;
            }

            if (!isMoveDone && isMoveCommand)
            {
                ConsoleIO.Print(Message.InvalidMove, true);
            }

            return isMoveCommand;
        }

        /// <summary>
        /// Execute the input if it is a service command
        /// </summary>
        /// <param name="input">Command</param>
        /// <param name="isMoveCommand">Is the command command for move</param>
        private void ProcessCommand(string input, bool isMoveCommand)
        {
            bool isCommandDone = false;
            if (input == "TOP")
            {
                isCommandDone = true;
                ConsoleIO.Print(this.scoreboard.ToString(), true);
            }
            else if (input == "EXIT")
            {
                isCommandDone = true;
                ConsoleIO.Print(Message.GoodBye, true);
                this.IsExit = true;
            }
            else if (input == "RESTART")
            {
                this.IsRestart = true;
                isCommandDone = true;
            }

            if (!isMoveCommand && !isCommandDone)
            {
                ConsoleIO.Print(Message.InvalidCommand, true);
            }
        }
    }
}
