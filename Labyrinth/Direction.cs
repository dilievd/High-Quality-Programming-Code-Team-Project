namespace Labyrinth
{
    /// <summary>
    /// Represent directions to move in the labyrinth
    /// </summary>
    public class Direction
    {
        /// <summary>
        /// Represent move to up cell in the labyrinth
        /// </summary>
        public static readonly Direction Up = new Direction(-1, 0);

        /// <summary>
        /// Represent move to down cell in the labyrinth
        /// </summary>
        public static readonly Direction Down = new Direction(1, 0);

        /// <summary>
        /// Represent move to left cell in the labyrinth
        /// </summary>
        public static readonly Direction Left = new Direction(0, -1);

        /// <summary>
        /// Represent move to right cell in the labyrinth
        /// </summary>
        public static readonly Direction Right = new Direction(0, 1);

        private Direction(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Represent move on rows
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Represent move on columns
        /// </summary>
        public int Y { get; private set; }
    }
}