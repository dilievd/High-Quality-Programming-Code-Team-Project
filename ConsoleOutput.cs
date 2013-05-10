using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    internal static class ConsoleOutput
    {
        internal static void Print(string info) 
        {
            Console.Write(info);
        }

        internal static void Print(string info, string newLineCharacter)
        {           
            Console.Write(info + newLineCharacter);
        }
    }
}
