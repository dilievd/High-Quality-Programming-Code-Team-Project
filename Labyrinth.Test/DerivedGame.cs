using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Test
{
    public class DerivedGame : Game
    {
        private DerivedEngine labyrinth;

        public DerivedGame(Scoreboard scoreboard, int[,] matrix)
            : base(scoreboard)
        {
            this.labyrinth = new DerivedEngine(matrix);
        }

        public bool DerivedProcessMove(string input)
        {
            bool result = base.ProcessMove(input);
            return result;
        }

        public bool DerivedProcessCommand(string input, bool isValidMove)
        {
            ProcessCommand(input, isValidMove);
            return base.IsExit;
        }
        //protected void AddResultToScoreBoard()
        //{
        //    if (this.scoreboard.IsTopResult(this.movesCount))
        //    {
        //        ConsoleIO.Print(Message.EnterNameForScoreBoard, false);
        //        string name = ConsoleIO.GetInput();
        //        Player currentPlayer = new Player(name, this.movesCount);
        //        this.scoreboard.AddPlayer(currentPlayer);
        //    }
        //}

        //protected void RunGame(string input)
        //{
        //    //string input = string.Empty;
        //    bool isGameOver = base.labyrinth.ExitFound(this.labyrinth.CurrentCell);

        //    while (!isGameOver && !this.IsRestart && !this.IsExit)
        //    {
        //        ConsoleIO.Print(this.labyrinth.ToString(), false);

        //        ConsoleIO.Print(Message.EnterMove, false);
        //        input = ConsoleIO.GetInput().ToUpper();
        //        this.ProcessInput(input);

        //        isGameOver = this.labyrinth.ExitFound(this.labyrinth.CurrentCell);
        //    }
        //}
    }
}
