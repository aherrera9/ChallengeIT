using ChallengeIT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Data.Contracts
{
    public interface IPlayerChallengeData
    {
        int NewChallenge(int challengingPlayerId, int opponentPlayerId, int categoryId);
        void UpdateChallenge(int challengeId, int challengeResponse);
        void CancelChallenge(int challengeId);
        PlayerChallenge GetChallenge(int challengeId);

        PendingChallenge GetPendingChallengeByUser(int playerId);
    }
}
