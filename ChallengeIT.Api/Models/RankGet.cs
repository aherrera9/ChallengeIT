using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeIT.Api.Models
{
    public class RankGet
    {
        /// <summary>
        /// The rank number for the player
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The name of the player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of wins the player has
        /// </summary>
        public int Wins { get; set; }

        /// <summary>
        /// The number of losses the player has
        /// </summary>
        public int Losses { get; set; }
    }
}
