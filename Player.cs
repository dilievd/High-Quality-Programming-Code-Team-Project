using System;

namespace Labyrinth
{
    class  Player: IComparable<Player>
    {
        private int movesCount; 
        private string playerName;

        public Player(int movesCount, string playerName)
        {
            this.movesCount = movesCount;
            this.playerName = playerName;
        }

        public int MovesCount 
        {
            get
            {
                return this.movesCount;
            }
        }

        public string PlayerName 
        {
            get
            {
                return this.playerName;
            }
        }

        public int CompareTo(Player other)
        {
            int compareResult = this.MovesCount.CompareTo(other.MovesCount);
            return compareResult;
        }
    }
}
