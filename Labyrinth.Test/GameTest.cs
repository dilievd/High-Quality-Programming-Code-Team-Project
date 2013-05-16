using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Labyrinth.Test
{
    
    
    /// <summary>
    ///This is a test class for Game and is intended
    ///to contain all Game Unit Tests
    ///</summary>
    [TestClass()]
    public class GameTest
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GameWithNullScoreboard()
        {

        }
    }
}
