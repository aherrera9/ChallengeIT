using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeIT.Api.Models;
using ChallengeIT.Api.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ChallengeIT.Api.Utilities.Enums;

namespace ChallengeIT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankController : ControllerBase
    {
        /// <summary>
        /// Get a list of the players that are available to challenge
        /// </summary>
        /// <returns>A list of the players that are available to challenge</returns>
        [HttpGet]
        public IActionResult Get(int categoryId, RankDateRange rankDateRange)
        {
            var playerList = new List<RankGet>()
            {
                new RankGet() { Rank = 1, Name = "Antonio", Wins = 7, Losses = 1 },
                new RankGet() { Rank = 2, Name = "Josh", Wins = 6, Losses = 2 },
                new RankGet() { Rank = 3, Name = "Hannes", Wins = 5, Losses = 3 },
                new RankGet() { Rank = 4, Name = "Imtiaz", Wins = 4, Losses = 4 },
                new RankGet() { Rank = 5, Name = "Nadav", Wins = 3, Losses = 5 },
                new RankGet() { Rank = 6, Name = "Esteban", Wins = 2, Losses = 6 },
                new RankGet() { Rank = 7, Name = "Rocco", Wins = 1, Losses = 7 }
            };

            return Ok(ApiHelper.ResponseWrapper(playerList));
        }
    }
}
