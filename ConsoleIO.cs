using System;
using System.Linq;

namespace Labyrinth
{
    internal static class ConsoleIO
    {
        internal static void Print(string info, bool moveOnNewLine, params string[] holder) 
        {
            Console.WriteLine();
            string message = string.Format(info, holder);
            if (moveOnNewLine)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message);
            }            
        }

        public static string GetInput()
        {
            ConsoleIO.Print(Message.EnterMove, false);
            string inputLine = Console.ReadLine();
            return inputLine;
        }
    }
}
