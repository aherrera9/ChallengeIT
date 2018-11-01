using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Data.Models
{
    public class PlayerChallenge
    {
        public int ChallengingPlayerId { get; set; }
        public int OpponentPlayerId { get; set; }
        public int ChallengeStatus { get; set; }
        public DateTime ChallengeDate { get; set; }

    }
}
