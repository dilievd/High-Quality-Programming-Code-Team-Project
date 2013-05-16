using System;

namespace Labyrinth
{
    public class Game
    {
        private Scoreboard scoreboard;
        private LabyrinthEngine labyrinth = new LabyrinthEngine();
        private int movesCount = 0;

        public Game(Scoreboard scoreboard)
        {
            if (scoreboard == null)
            {
                throw new ArgumentNullException(
                    "Invalid input! Scoreboard cannot be null.");
            }

            this.IsExit = false;
            this.IsRestart = false;
            this.scoreboard = scoreboard;
        }

        /// <summary>
        /// Show whether is entered EXIT command
        /// </summary>
        public bool IsExit { get; private set; }

        private bool IsRestart { get; set; }

        /// <summary>
        /// Run the game
        /// </summary>
        public void Play()
        {
            ConsoleIO.Print(Message.Welcome, true);
            RunGame();

            if (!this.IsRestart && !this.IsExit)
            {
                ConsoleIO.Print(Message.Win, false, this.movesCount.ToString());
                AddResultToScoreBoard();
                ConsoleIO.Print(this.scoreboard.ToString(), false);
            }
        }

        private void AddResultToScoreBoard()
        {
            if (this.scoreboard.IsTopResult(this.movesCount))
            {
                ConsoleIO.Print(Message.EnterNameForScoreBoard, false);
                string name = ConsoleIO.GetInput();
                Player currentPlayer = new Player(name, this.movesCount);
                this.scoreboard.AddPlayer(currentPlayer);
            }
        }

        private void RunGame()
        {
            string input = string.Empty;
            bool isGameOver = this.labyrinth.ExitFound(this.labyrinth.CurrentCell);

            while (!isGameOver && !this.IsRestart && !this.IsExit)
            {
                ConsoleIO.Print(this.labyrinth.ToString(), false);

                ConsoleIO.Print(Message.EnterMove, false);
                input = ConsoleIO.GetInput().ToUpper();
                this.ProcessInput(input);

                isGameOver = this.labyrinth.ExitFound(this.labyrinth.CurrentCell);
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
            if (!isMoveCommand)
            {
                if (input == "TOP")
                {
                    ConsoleIO.Print(this.scoreboard.ToString(), true);
                }
                else if (input == "EXIT")
                {                    
                    ConsoleIO.Print(Message.GoodBye, true);
                    this.IsExit = true;
                }
                else if (input == "RESTART")
                {
                    this.IsRestart = true;                    
                }
                else
                {
                    ConsoleIO.Print(Message.InvalidCommand, true);
                }
            }         
        }
    }
}
