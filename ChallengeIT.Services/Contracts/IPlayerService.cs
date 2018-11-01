using ChallengeIT.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Services.Contracts
{
    public interface IPlayerService
    {
        /// <summary>
        /// Get a list of players from the data store
        /// </summary>
        /// <returns>A list of player</returns>
        Task<IEnumerable<Player>> GetPlayers();
    }
}
