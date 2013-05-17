using System;

namespace Labyrinth
{
    /// <summary>
    /// Represent a demo of the project - start point
    /// </summary>
    public class LabyrinthDemo
    {
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
