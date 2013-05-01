using System;

namespace Labyrinth
{
	// smilih se nad vas kolegi, ne sym puskal obfuskatora, shtoto se zamislih, che i vie moze da imate
    class LabTest
    {
        static void Main()
        {
            Scoreboard ladder = new Scoreboard();
            Random rand = new Random();
            while (1 == 1)
            {
                Game game = new Game(rand, ladder);
            }
        }
    }
}
