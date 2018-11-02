using ChallengeIT.Data.Contracts;
using ChallengeIT.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Services.Services
{
    public class ChallengeService : IChallengeService
    {
        #region Properties

        /// <summary>
        /// The interface for accessing challenge data
        /// </summary>
        private readonly IPlayerChallengeData _ChallengeData;

        #endregion

        public async Task<int> CreateChallenge(int categoryId, int challengerId, int opponentId)
        {
            int challengeId = await Task.Run(() => _ChallengeData.NewChallenge(challengerId, opponentId, categoryId));
            return challengeId;
        }
    }
}
