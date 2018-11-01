using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeIT.Services.Utilities
{
    public class Enums
    {
        /// <summary>
        /// The date range that the rank is based on
        /// </summary>
        public enum RankDateRange
        {
            Day,
            Week,
            Month
        }

        /// <summary>
        /// The status of the challenge that was issued
        /// </summary>
        public enum ChallengeStatus
        {
            Accepted,
            Declined,
            Waiting
        }

        /// <summary>
        /// The result of the challenge after accepted
        /// </summary>
        public enum ChallengeResult
        {
            Result,
            Win,
            Loss,
            CancelledAbandoned,
            NA,
            PendingResult
        }
    }
}
