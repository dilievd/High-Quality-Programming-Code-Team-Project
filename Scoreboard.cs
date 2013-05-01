using System;
using System.Collections.Generic;
using System.Linq;

namespace Labyrinth
{
    class Scoreboard
    {
        private const int TOP_RESULTS_CAPACITY = 5;

        private List<Player> topScores;

        public Scoreboard()
        {
            topScores = new List<Player>();
            topScores.Capacity = TOP_RESULTS_CAPACITY;
        }

        public void PrintScoreBoard()
        {
            if (topScores.Count == 0)
            {
                Message.ScoreboardEmpty();
            }
            else
            {
                for (int index = 0; index < topScores.Count; index++)
                {
                    Console.WriteLine("{0}. {1} --> {2} moves", index + 1,
                        topScores[index].PlayerName, topScores[index].MovesCount);
                }
            }
        }

        public bool PlayerQualifiesInScoreboard(int result)
        {
            if (topScores.Count < TOP_RESULTS_CAPACITY )
            {
                return true;
            }

            if (result < topScores.Max().MovesCount)
            {
                return true;
            }

            return false;
        }

        public void AddPlayerInScoreboard(string playerName, int movesCount)
        {
            Player player = new Player(playerName, movesCount);
            if (topScores.Count == topScores.Capacity)
            {
                topScores[topScores.Count - 1] = player;
            }
            else
            {
                topScores.Add(player);
            }

            topScores.Sort();
        }
    }
}
