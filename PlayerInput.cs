using System;

namespace Labyrinth
{
    static class PlayerInput
    {
        public static string GetInput()
        {
            ConsoleOutput.Print(Message.EnterMoveMsg, false);
            string inputLine = Console.ReadLine();
            return inputLine;
        }
    }
}