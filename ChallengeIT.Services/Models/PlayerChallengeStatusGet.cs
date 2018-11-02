using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeIT.Services.Utilities;

namespace ChallengeIT.Services.Models
{
    public class PlayerChallengeStatusGet
    {
        public int ChallengeId { get; set; }
        public int OpponentId { get; set; }
        public int ChallengerId { get; set; }
        public Enums.ChallengeStatus Status { get; set; }
    }
}
