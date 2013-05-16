using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Test
{
    /// <summary>
    /// Summary description for ConsoleIOTest
    /// </summary>
    [TestClass]
    public class ConsoleIOTest
    {
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConsoleIOPrintNull()
        {
            ConsoleIO.Print(null, false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConsoleIOPrintMessage()
        {
            ConsoleIO.Print(null, false);
        }
    }
}
