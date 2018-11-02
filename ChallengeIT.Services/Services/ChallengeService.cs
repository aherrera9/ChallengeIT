using ChallengeIT.Data.Contracts;
using ChallengeIT.Services.Contracts;
using ChallengeIT.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChallengeIT.Services.Utilities;

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
        #region Constructors

        public ChallengeService(IPlayerChallengeData challengeData)
        {
            _ChallengeData = challengeData;
        }

        #endregion

        public async Task<int> CreateChallenge(int categoryId, int challengerId, int opponentId)
        {
            int challengeId = await Task.Run(() => _ChallengeData.NewChallenge(challengerId, opponentId, categoryId));

            // send email
            Email.SendEmail();

            return challengeId;
        }

        public async Task<PlayerChallengeStatusGet> GetChallengeStatus(int playerId)
        {
            var pendingChallenge = new PlayerChallengeStatusGet();
            var pendingChallengeData = await Task.Run(() => _ChallengeData.GetPendingChallengeByUser(playerId));

            if (pendingChallengeData != null)
            {
                pendingChallenge.ChallengeId = pendingChallengeData.ChallengeId;
                pendingChallenge.OpponentId = pendingChallengeData.OpponentPlayerId;
                pendingChallenge.ChallengerId = pendingChallengeData.ChallengingPlayerId;
                pendingChallenge.Status = Enums.ChallengeStatus.Waiting;
            }

            return pendingChallenge;
        }
    }
}
