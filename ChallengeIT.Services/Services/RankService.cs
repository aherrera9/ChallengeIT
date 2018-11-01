using ChallengeIT.Data.Contracts;
using ChallengeIT.Services.Contracts;
using ChallengeIT.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Services.Services
{
    public class RankService : IRankService
    {
        #region Properties

        /// <summary>
        /// The interface for accessing player rank data
        /// </summary>
        private readonly IRankData _RankData;

        #endregion
        #region Constructors

        /// <summary>
        /// The constructor for the class
        /// </summary>
        /// <param name="rankData">The interface for accessing player rank data</param>
        public RankService(IRankData rankData)
        {
            _RankData = rankData;
        }

        #endregion
        #region Methods

        /// <summary>
        /// Get a list of players from the data store
        /// </summary>
        /// <returns>A list of players</returns>
        public async Task<IEnumerable<Rank>> GetRanks()
        {
            List<Rank> ranks = new List<Rank>();

            // get the data from the data store
            var ranksData = Task.Run(() => _RankData.GetRank(DateTime.Now, DateTime.Now))
                .GetAwaiter()
                .GetResult();

            // convert the data to a service type variable
            foreach (var rankData in ranksData)
            {
                ranks.Add(new Rank()
                {
                    Number = 1,
                    Name = "Name",
                    Wins = 1,
                    Losses = 1
                });
            }

            return ranks;
        }

        #endregion
    }
}