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

namespace ChallengeIT.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        #region Properties

        private readonly IPlayerService _playerService;
        private readonly IChallengeService _challengeService;

        #endregion
        #region Controller

        /// <summary>
        /// The controller for the class
        /// </summary>
        public PlayerController(IPlayerService playerService, IChallengeService challengeService)
        {
            _playerService = playerService;
            _challengeService = challengeService;
        }


        #endregion
        #region Methods

        /// <summary>
        /// Get a list of the players that are available to challenge
        /// </summary>
        /// <returns>A list of the players that are available to challenge</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var players = await _playerService.GetPlayers();

            var playerGets = new List<PlayerGet>();
            foreach (var player in players)
            {
                playerGets.Add(new PlayerGet()
                {
                    Id = player.Id,
                    Name = player.Name
                });
            }

            return Ok(ApiHelper.ResponseWrapper(playerGets));
        }

        [HttpGet]
        [Route("{0}/ChallengeStatus")]
        public async Task<IActionResult> CreateChallenge(int playerId)
        {
            var challengeStatus = await _challengeService.GetChallengeStatus(playerId);

            PlayerChallengeStatusGet pcStatus = new PlayerChallengeStatusGet()
            {
                ChallengeId = challengeStatus.ChallengeId,
                ChallengerId = challengeStatus.ChallengerId,
                OpponentId = challengeStatus.OpponentId,
                Status = challengeStatus.Status
            };

            return Ok(ApiHelper.ResponseWrapper(challengeStatus));
        }

        #endregion
    }
}
