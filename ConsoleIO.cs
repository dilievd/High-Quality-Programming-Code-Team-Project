using System;
using System.Linq;

namespace Labyrinth
{
    /// <summary>
    /// Read the input and print the output on the console
    /// </summary>
    internal static class ConsoleIO
    {
        /// <summary>
        /// Print information on the console
        /// </summary>
        /// <param name="info">Information to be print</param>
        /// <param name="moveOnNewLine">To add or not new line</param>
        /// <param name="holder">To use or not placeholders</param>
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

        /// <summary>
        /// Read the input from the console
        /// </summary>
        /// <returns>Input from the console</returns>
        public static string GetInput(string message)
        {
            ConsoleIO.Print(message, false);
            string inputLine = Console.ReadLine();
            return inputLine;
        }
    }
}
