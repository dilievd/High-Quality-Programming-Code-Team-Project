﻿using System;

namespace Labyrinth
{
    // smilih se nad vas kolegi, ne sym puskal obfuskatora, shtoto se zamislih, che i vie moze da imate
    public class LabyrinthDemo
    {
        public static void Main()
        {
            Game game = new Game();
            while (true)
            {
                game.Play();
            }
        }
    }
}
