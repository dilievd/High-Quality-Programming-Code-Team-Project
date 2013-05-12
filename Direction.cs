namespace Labyrinth
{
    public class Direction
    {
        public static readonly Direction Up = new Direction(-1, 0);
        public static readonly Direction Down = new Direction(1, 0);
        public static readonly Direction Left = new Direction(0, -1);
        public static readonly Direction Right = new Direction(0, 1);

        public int X { get; private set; }
        public int Y { get; private set; }

        private Direction(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}