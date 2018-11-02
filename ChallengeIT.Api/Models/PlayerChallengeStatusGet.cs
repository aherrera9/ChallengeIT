using ChallengeIT.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeIT.Api.Models
{
    public class PlayerChallengeStatusGet
    {
        public int ChallengeId { get; set; }
        public int OpponentId { get; set; }
        public int ChallengerId { get; set; }
        public Enums.ChallengeStatus Status { get; set; }
    }
}
