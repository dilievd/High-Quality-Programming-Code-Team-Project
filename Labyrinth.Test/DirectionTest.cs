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
        public void DirectionUp()
        {
            var coordX = Direction.Up.X;
            var coordY = Direction.Up.Y;

            Assert.AreEqual(-1, coordX);
            Assert.AreEqual(0, coordY);
        }

        [TestMethod]
        public void DirectionDown()
        {
            var coordX = Direction.Down.X;
            var coordY = Direction.Down.Y;

            Assert.AreEqual(1, coordX);
            Assert.AreEqual(0, coordY);
        }

        [TestMethod]
        public void DirectionLeft()
        {
            var coordX = Direction.Left.X;
            var coordY = Direction.Left.Y;

            Assert.AreEqual(0, coordX);
            Assert.AreEqual(-1, coordY);
        }

        [TestMethod]
        public void DirectionRight()
        {
            var coordX = Direction.Right.X;
            var coordY = Direction.Right.Y;

            Assert.AreEqual(0, coordX);
            Assert.AreEqual(1, coordY);
        }
    }
}
