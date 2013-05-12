using System;

namespace Labyrinth
{
    public class  Player: IComparable<Player>
    {
        private string name;
        private int movesCount; 

        public Player(string name, int movesCount)
        {
            this.Name = name;
            this.MovesCount = movesCount;
        }

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
                    throw new ArgumentOutOfRangeException("Can't escape from labyrinth in " + 
                        "less moves than the shortest distance from center of the labyrinth!");
                }

                this.movesCount = value;
            }
        }

        public int CompareTo(Player other)
        {
            int comparePlayer = this.MovesCount.CompareTo(other.MovesCount);
            return comparePlayer;
        }
    }
}