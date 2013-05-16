using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labyrinth.Test
{
    /// <summary>
    /// This is a test class for Direction and is intended
    /// to contain all Direction Unit Tests
    /// </summary>
    [TestClass]
    public class DirectionTest
    {
        [TestMethod]
        public void DirectionUpCoordX()
        {
            var coordX = Direction.Up.X;
            var coordY = Direction.Up.Y;
            Assert.AreEqual(-1, coordX);
            Assert.AreEqual(0, coordY);
        }
    }
}
