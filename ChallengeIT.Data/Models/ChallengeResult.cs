using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Data.Models
{
    public class ChallengeResult
    {
        public int ChallengingPlayerId { get; set; }
        public int OpponentPlayerId { get; set; }
        public int Result { get; set; }
    }
}
