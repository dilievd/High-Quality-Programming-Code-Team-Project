using System;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    /// <summary>
    /// Read the input and print the output on the console
    /// </summary>
    public static class ConsoleIO
    {
        /// <summary>
        /// Print information on the console
        /// </summary>
        /// <param name="info">Information to be print</param>
        /// <param name="moveOnNewLine">To add or not new line</param>
        /// <param name="holder">To use or not placeholders</param>
        public static string Print(string info, bool moveOnNewLine, params string[] holder) 
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine();            
            result.Append(string.Format(info, holder));
            if (moveOnNewLine)
            {
                result.AppendLine();
            }

            string resultToString = result.ToString();
            Console.Write(resultToString);

            return resultToString;                        
        }

        /// <summary>
        /// Read the input from the console
        /// </summary>
        /// <returns>Input from the console</returns>
        public static string GetInput()
        {
            string inputLine = Console.ReadLine();
            return inputLine;
        }
    }
}
