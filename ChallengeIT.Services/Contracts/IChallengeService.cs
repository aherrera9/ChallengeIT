using ChallengeIT.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeIT.Services.Contracts
{
    public interface IChallengeService
    {
        Task<int> CreateChallenge(int catagoryId, int challengerId, int opponentId);
        Task<PlayerChallengeStatusGet> GetChallengeStatus(int playerId);
    }
}
