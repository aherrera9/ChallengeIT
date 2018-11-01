using ChallengeIT.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ChallengeIT.Services.Utilities.Enums;

namespace ChallengeIT.Services.Contracts
{
    public interface IRankService
    {
        /// <summary>
        /// Get a list of player ranks from the data store
        /// </summary>
        /// <returns>A list of player</returns>
        Task<IEnumerable<Rank>> GetRanks(RankDateRange rankDateRange);
    }
}
