using ChallengeIT.Data.Contracts;
using ChallengeIT.Services.Contracts;
using ChallengeIT.Services.Extensions;
using ChallengeIT.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ChallengeIT.Services.Utilities.Enums;

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
        public async Task<IEnumerable<Rank>> GetRanks(RankDateRange rankDateRange)
        {
            var ranks = await this.GetRanksFromDatabase(rankDateRange);
            return ranks;
        }

        private async Task<IEnumerable<Rank>> GetRanksFromDatabase(RankDateRange rankDateRange)
        {
            List<Rank> ranks = new List<Rank>();

            DateTime startDate = this.GetStartDateOfRange(rankDateRange);
            DateTime endDate = this.GetEndDateOfRange(rankDateRange);

            // get the data from the data store
            var ranksData = Task.Run(() => _RankData.GetRank(startDate, endDate))
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

        private DateTime GetStartDateOfRange(RankDateRange rankDateRange)
        {
            DateTime date = DateTime.Now;
            switch (rankDateRange)
            {
                case RankDateRange.Week:
                    return date.FirstDayOfWeek();
                case RankDateRange.Month:
                    return date.FirstDayOfMonth();
                default:
                    return date.Date;
            }
        }

        private DateTime GetEndDateOfRange(RankDateRange rankDateRange)
        {
            DateTime date = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            switch (rankDateRange)
            {
                case RankDateRange.Week:
                    returnDate = date.LastDayOfWeek();
                    break;
                case RankDateRange.Month:
                    returnDate = date.LastDayOfMonth();
                    break;
                default:
                    returnDate = date.Date.AddHours(24);
                    break;
            }

            return returnDate.AddMilliseconds(-1);
        }

        #endregion
    }
}