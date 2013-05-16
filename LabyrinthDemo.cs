using System;

namespace Labyrinth
{
    public class LabyrinthDemo
    {
        /// <summary>
        /// Start the game
        /// </summary>
        public static void Main()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            bool startNewGame = true;
            while (startNewGame)
            {
                Game game = new Game(scoreboard);
                game.Play();
                startNewGame = !game.IsExit;
            }
        }
    }
}
