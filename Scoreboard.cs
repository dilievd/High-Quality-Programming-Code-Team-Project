using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    /// <summary>
    /// Represent the list of players with top results 
    /// </summary>
    public sealed class Scoreboard
    {
        private const int NUMBER_TOP_RESULTS = 5;
        private static Scoreboard instance;
        private List<Player> topPlayers = new List<Player>(NUMBER_TOP_RESULTS);        

        private Scoreboard()
        { 
        }

        public static Scoreboard Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Scoreboard();
                }

                return instance;
            }
        }

        public static void Clear()
        {
            instance = null;
        }

        /// <summary>
        /// Add player to the scoreboard
        /// </summary>
        /// <param name="player">Changed scoreboard</param>
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

        /// <summary>
        /// Find is the current result top result
        /// </summary>
        /// <param name="result">Current result</param>
        /// <returns>Is or is not current result top result</returns>
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

        /// <summary>
        /// Create string representation of the scoreboard
        /// </summary>
        /// <returns>String representation of the scoreboard</returns>
        public override string ToString()
        {
            StringBuilder resultList = new StringBuilder();
            if (this.topPlayers.Count == 0)
            {
                resultList.Append(Message.SCOREBOARD_EMPTY);
            }
            else
            {
                resultList.AppendLine("Scoreboard:");
                for (int index = 0; index < this.topPlayers.Count; index++)
                {
                    string currentResult = string.Format(
                        "{0}. {1} --> {2} moves",
                        index + 1, 
                        this.topPlayers[index].Name,
                        this.topPlayers[index].MovesCount);
                    resultList.AppendLine(currentResult);
                }
            }

            return resultList.ToString();
        }
    }
}
