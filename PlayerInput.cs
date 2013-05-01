using System;

namespace Labyrinth
{
    static class PlayerInput
    {
        public static string GetInput()
        {
            Message.EnterMove();
            string inputLine = Console.ReadLine();
            return inputLine;
        }
    }
}