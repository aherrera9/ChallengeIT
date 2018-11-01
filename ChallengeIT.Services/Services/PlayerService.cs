using ChallengeIT.Data.Contracts;
using ChallengeIT.Services.Contracts;
using ChallengeIT.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Services.Services
{
    public class PlayerService : IPlayerService
    {
        #region Properties

        /// <summary>
        /// The interface for accessing player data
        /// </summary>
        private readonly IPlayerData _PlayerData;

        #endregion
        #region Constructors

        /// <summary>
        /// The constructor for the class
        /// </summary>
        /// <param name="playerData">The interface for accessing player data</param>
        public PlayerService(IPlayerData playerData)
        {
            _PlayerData = playerData;
        }

        #endregion
        #region Methods
        
        /// <summary>
        /// Get a list of players from the data store
        /// </summary>
        /// <returns>A list of players</returns>
        public async Task<IEnumerable<Player>> GetPlayers()
        {
            List<Player> players = new List<Player>();

            // get the data from the data store
            var playersDate = await Task.Run(() => _PlayerData.GetPlayers());

            // convert the data to a service type variable
            foreach (var playerDate in playersDate)
            {
                players.Add(new Player()
                {
                    Id = playerDate.Id,
                    Name = playerDate.Name
                });
            }

            return players;
        }

        #endregion
    }
}
