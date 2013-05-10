using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    internal static class ConsoleIO
    {
        internal static void Print(string info, bool moveOnNewLine) 
        {
            if (moveOnNewLine)
            {
                Console.WriteLine(info);
            }
            else
            {
                Console.Write(info);
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
