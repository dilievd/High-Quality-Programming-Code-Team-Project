using System;

namespace Labyrinth
{
    static class PlayerInput
    {
        public static string GetInput()
        {
            ConsoleOutput.Print(Message.EnterMove, false);
            string inputLine = Console.ReadLine();
            return inputLine;
        }
    }
}