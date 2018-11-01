﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeIT.Api.Models;
using ChallengeIT.Api.Utilities;
using ChallengeIT.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ChallengeIT.Api.Utilities.Enums;

namespace ChallengeIT.Api.Controllers
{
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
        public async Task<IActionResult> Get(int categoryId, RankDateRange rankDateRange)
        {
            var playerList = new List<RankGet>()
            {
                new RankGet() { Number = 1, Name = "Antonio", Wins = 7, Losses = 1 },
                new RankGet() { Number = 2, Name = "Josh", Wins = 6, Losses = 2 },
                new RankGet() { Number = 3, Name = "Hannes", Wins = 5, Losses = 3 },
                new RankGet() { Number = 4, Name = "Imtiaz", Wins = 4, Losses = 4 },
                new RankGet() { Number = 5, Name = "Nadav", Wins = 3, Losses = 5 },
                new RankGet() { Number = 6, Name = "Esteban", Wins = 2, Losses = 6 },
                new RankGet() { Number = 7, Name = "Rocco", Wins = 1, Losses = 7 }
            };

            return Ok(ApiHelper.ResponseWrapper(playerList));

            var ranks = await _rankService.GetRanks();

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
