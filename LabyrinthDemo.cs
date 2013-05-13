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
            Scoreboard scoreboard = new Scoreboard();
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
