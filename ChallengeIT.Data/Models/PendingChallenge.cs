using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Data.Models
{
    public class PendingChallenge
    {
        public int ChallengingPlayerId { get; set; }
        public int OpponentPlayerId { get; set; }
        public int ChallengeId { get; set; }
    }
}
