﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Labyrinth
{
    class Ladder
    {
        private const int TOP_RESULTS_CAPACITY = 5;

        private List<Player> topResults;

        public Ladder()
        {
            topResults = new List<Player>();
            topResults.Capacity = TOP_RESULTS_CAPACITY;
        }

        public void PrintLadder()
        {
            if (topResults.Count == 0)
            {
                Message.ScoreboardEmpty();
            }
            else
            {
                for (int index = 0; index < topResults.Count; index++)
                {
                    Console.WriteLine("{0}. {1} --> {2} moves", index + 1,
                        topResults[index].PlayerName, topResults[index].MovesCount);
                }
            }
        }

        public bool ResultQualifiesInLadder(int result)
        {
            if (topResults.Count < TOP_RESULTS_CAPACITY )
            {
                return true;
            }

            if (result < topResults.Max().MovesCount)
            {
                return true;
            }

            return false;
        }

        public void AddResultInLadder(int movesCount, string playerName)
        {
            Player result = new Player(movesCount, playerName);
            if (topResults.Count == topResults.Capacity)
            {
                topResults[topResults.Count - 1] = result;
            }
            else
            {
                topResults.Add(result);
            }

            topResults.Sort();
        }
    }
}
