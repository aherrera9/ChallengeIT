using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeIT.Services.Models
{
    public class Player
    {
        /// <summary>
        /// The unique identifier for the player
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the player
        /// </summary>
        public string Name { get; set; }
    }
}
