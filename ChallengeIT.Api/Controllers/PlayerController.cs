using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeIT.Api.Models;
using ChallengeIT.Api.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeIT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        /// <summary>
        /// Get a list of the players that are available to challenge
        /// </summary>
        /// <returns>A list of the players that are available to challenge</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var playerList = new List<PlayerGet>()
            {
                new PlayerGet() { Id = 1, Name = "Antonio" },
                new PlayerGet() { Id = 2, Name = "Josh" },
                new PlayerGet() { Id = 3, Name = "Hannes" },
                new PlayerGet() { Id = 4, Name = "Imtiaz" },
                new PlayerGet() { Id = 5, Name = "Nadav" },
                new PlayerGet() { Id = 6, Name = "Esteban" },
                new PlayerGet() { Id = 7, Name = "Rocco" }
            };

            return Ok(ApiHelper.ResponseWrapper(playerList));
        }
    }
}
