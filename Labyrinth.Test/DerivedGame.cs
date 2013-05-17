using System;
using System.Linq;

namespace Labyrinth.Test
{
    /// <summary>
    /// This class is derived from Game so 
    /// that we can test Game methods
    /// </summary>
    public class DerivedGame : Game
    {
        private readonly DerivedEngine labyrinth;

        public DerivedGame(Scoreboard scoreboard, int[,] matrix)
            : base(scoreboard)
        {
            this.labyrinth = new DerivedEngine(matrix);
        }

        public bool DerivedProcessMove(string input)
        {
            bool result = this.ProcessMove(input);
            return result;
        }

        public bool DerivedProcessCommand(string input, bool isValidMove)
        {
            this.ProcessCommand(input, isValidMove);
            return this.IsExit;
        }
    }
}
