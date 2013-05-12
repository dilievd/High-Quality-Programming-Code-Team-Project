using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class Scoreboard
    {
        private const int NUMBER_TOP_RESULTS = 5;
        private List<Player> topPlayers;

        public Scoreboard()
        {
            topPlayers = new List<Player>(NUMBER_TOP_RESULTS);
        }

        public void AddPlayer(Player player)
        {
            if (this.topPlayers.Count == NUMBER_TOP_RESULTS)
            {
                this.topPlayers[NUMBER_TOP_RESULTS - 1] = player;
            }
            else
            {
                this.topPlayers.Add(player);
            }

            this.topPlayers.Sort();
        }

        public bool IsTopResult(int result)
        {
            bool isTopResult = false;
            if (this.topPlayers.Count < NUMBER_TOP_RESULTS)
            {
                isTopResult = true;
            }
            else if (result < this.topPlayers.Max().MovesCount)
            {
                isTopResult = true;
            }

            return isTopResult;
        }

        public override string ToString()
        {
            StringBuilder resultList = new StringBuilder();
            if (this.topPlayers.Count == 0)
            {
                resultList.Append(Message.ScoreBoardEmpty);
            }
            else
            {
                resultList.AppendLine("Scoreboard:");
                for (int index = 0; index < this.topPlayers.Count; index++)
                {
                    string currentResult = string.Format("{0}. {1} --> {2} moves",
                        index + 1, topPlayers[index].Name, topPlayers[index].MovesCount);
                    resultList.AppendLine(currentResult);
                }
            }

            return resultList.ToString();
        }
    }
}
