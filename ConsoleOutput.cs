using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    internal static class ConsoleOutput
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
    }
}
