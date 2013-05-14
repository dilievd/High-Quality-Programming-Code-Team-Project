using System;

namespace Labyrinth
{
    /// <summary>
    /// Represent a player in the game
    /// </summary>
    public class Player: IComparable<Player>
    {
        private string name;
        private int movesCount; 

        public Player(string name, int movesCount)
        {
            this.Name = name;
            this.MovesCount = movesCount;
        }

        /// <summary>
        /// Represent the name of the plyer
        /// </summary>
        public string Name 
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        "Invalid input! Name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Represent the result of the player (number of moves to escape from the labyrinth)
        /// </summary>
        public int MovesCount
        {
            get
            {
                return this.movesCount;
            }

            private set
            {
                if (value < LabyrinthEngine.LABYRINTH_SIZE / 2)
                {
                    throw new ArgumentOutOfRangeException("Cannot escape from labyrinth in " + 
                        "less moves than the shortest distance from center of the labyrinth!");
                }

                this.movesCount = value;
            }
        }

        /// <summary>
        /// Compare two players by their result - MovesCount
        /// </summary>
        /// <param name="other">Player compared to the current one</param>
        /// <returns>1, 0 or -1 according to MovesCount property value of both players</returns>
        public int CompareTo(Player other)
        {
            int comparePlayer = this.MovesCount.CompareTo(other.MovesCount);
            return comparePlayer;
        }
    }
}