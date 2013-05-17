using System;

namespace Labyrinth
{
    public class Game
    {
        private Scoreboard scoreboard;
        private Engine labyrinth = new Engine();
        private int movesCount = 0;
        private bool isRestart = false;

        /// <summary>
        /// Create game
        /// </summary>
        /// <param name="scoreboard">Used scoreboard to save the results</param>
        /// <exception cref="ArgumentNullException">
        /// If the used scoreboard is null</exception>
        public Game(Scoreboard scoreboard)
        {
            if (scoreboard == null)
            {
                throw new ArgumentNullException(
                    "Invalid input! Scoreboard cannot be null.");
            }

            this.IsExit = false;
            this.isRestart = false;
            this.scoreboard = scoreboard;
        }

        /// <summary>
        /// Show whether is entered EXIT command
        /// </summary>
        public bool IsExit { get; private set; }

        /// <summary>
        /// Satrt game
        /// </summary>
        public void Play()
        {
            ConsoleIO.Print(Message.WELCOME, true);
            RunGame();

            if (!this.isRestart && !this.IsExit)
            {
                ConsoleIO.Print(Message.WIN, false, this.movesCount.ToString());
                AddResultToScoreBoard();
                ConsoleIO.Print(this.scoreboard.ToString(), false);
            }
        }

        /// <summary>
        /// Run game - read commands and process them
        /// </summary>
        private void RunGame()
        {
            string input = string.Empty;
            bool isGameOver = this.labyrinth.ExitFound(this.labyrinth.CurrentCell);

            while (!isGameOver && !this.isRestart && !this.IsExit)
            {
                ConsoleIO.Print(this.labyrinth.ToString(), false);

                ConsoleIO.Print(Message.ENTER_MOVE, false);
                input = ConsoleIO.GetInput().ToUpper();
                this.ProcessInput(input);

                isGameOver = this.labyrinth.ExitFound(this.labyrinth.CurrentCell);
            }
        }

        /// <summary>
        /// Add result of the game to the scoreboard
        /// </summary>
        private void AddResultToScoreBoard()
        {
            if (this.scoreboard.IsTopResult(this.movesCount))
            {
                ConsoleIO.Print(Message.ENTER_NAME_FOR_SCOREBOARD, false);
                string name = ConsoleIO.GetInput();
                Player currentPlayer = new Player(name, this.movesCount);
                this.scoreboard.AddPlayer(currentPlayer);
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
        protected bool ProcessMove(string input)
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
                ConsoleIO.Print(Message.INVALID_MOVE, true);
            }

            return isMoveCommand;
        }

        /// <summary>
        /// Execute the input if it is a service command
        /// </summary>
        /// <param name="input">Command</param>
        /// <param name="isMoveCommand">Is the command command for move</param>
        protected void ProcessCommand(string input, bool isMoveCommand)
        {            
            if (!isMoveCommand)
            {
                if (input == "TOP")
                {
                    ConsoleIO.Print(this.scoreboard.ToString(), true);
                }
                else if (input == "EXIT")
                {
                    ConsoleIO.Print(Message.GOOD_BYE, true);
                    this.IsExit = true;
                }
                else if (input == "RESTART")
                {
                    this.isRestart = true;                    
                }
                else
                {
                    ConsoleIO.Print(Message.INVALID_COMMAND, true);
                }
            }
        }
    }
}
