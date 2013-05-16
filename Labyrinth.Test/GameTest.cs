using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Labyrinth.Test
{
    
    
    /// <summary>
    /// This is a test class for Game and is intended
    /// to contain all Game Unit Tests
    /// </summary>
    [TestClass()]
    public class GameTest
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GameWithNullScoreboard()
        {
            Game game = new Game(null);
        }

        //[TestMethod]
        //public void GamePlay()
        //{
        //    Scoreboard scoreboard = Scoreboard.Instance;
        //    Game game = new Game(scoreboard);
        //    game.Play();
        //}
    }
}
