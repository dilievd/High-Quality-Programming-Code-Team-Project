using System;

namespace Labyrinth
{
    class  Player: IComparable<Player>
    {
        private string playerName;
        private int movesCount; 

        public Player(string playerName, int movesCount)
        {
            this.playerName = playerName;
            this.movesCount = movesCount;
        }

        public string PlayerName 
        {
            get
            {
                return this.playerName;
            }
        }

        public int MovesCount
        {
            get
            {
                return this.movesCount;
            }
        }

        public int CompareTo(Player other)
        {
            int comparePlayer = this.MovesCount.CompareTo(other.MovesCount);
            return comparePlayer;
        }
    }
}