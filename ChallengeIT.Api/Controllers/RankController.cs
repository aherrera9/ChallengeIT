using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeIT.Api.Models;
using ChallengeIT.Api.Utilities;
using ChallengeIT.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ChallengeIT.Services.Utilities.Enums;

namespace ChallengeIT.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class RankController : ControllerBase
    {
        #region Properties

        private readonly IRankService _rankService;

        #endregion

        /// <summary>
        /// Get a list of player ranks
        /// </summary>
        /// <returns>A list of player ranks</returns>
        [HttpGet]
        public async Task<IActionResult> Get(int categoryId, RankDateRange rankDateRange = RankDateRange.Day)
        {
            var ranks = await _rankService.GetRanks(rankDateRange);

            var rankGets = new List<RankGet>();
            foreach (var rank in ranks)
            {
                rankGets.Add(new RankGet()
                {
                    Number = rank.Number,
                    Name = rank.Name,
                    Wins = rank.Wins,
                    Losses = rank.Losses
                });
            }

            return Ok(ApiHelper.ResponseWrapper(rankGets));
        }
    }
}
