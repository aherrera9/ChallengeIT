using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeIT.Api.Models
{
    public class Challenge
    {
        public int CategoryId { get; set; }
        public int OpponentId { get; set; }
        public int ChallengerId { get; set; }
    }
}
