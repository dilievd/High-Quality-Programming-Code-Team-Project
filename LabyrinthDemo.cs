using System;

namespace Labyrinth
{
    // smilih se nad vas kolegi, ne sym puskal obfuskatora, shtoto se zamislih, che i vie moze da imate
    public class LabyrinthDemo
    {
        public static void Main()
        {
            Scoreboard scoreboard = new Scoreboard();
            bool startNewGame = true;
            while (startNewGame)
            {
                Game game = new Game(scoreboard);
                game.Play();

            }
        }
    }
}
