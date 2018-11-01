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
        public string ChallengerName { get; set; }
        public int OpponentPlayerId { get; set; }
        public string OpponentName { get; set; }
        public int Result { get; set; }
        public int CategoryId { get; set; }
    }
}
