using ChallengeIT.Api.Utilities;
using ChallengeIT.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ChallengeIT.Services.Utilities;
using Microsoft.AspNetCore.Cors;
using ChallengeIT.Api.Models;

namespace ChallengeIT.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/{0}/")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        #region Properties

        private readonly IChallengeService _challengeService;

        #endregion
        #region Controller

        public ChallengeController(IChallengeService challengeService)
        {
            _challengeService = challengeService;
        }

        #endregion
        #region Methods

        [HttpPost]
        [Route("CreateChallenge")]
        public async Task<IActionResult> CreateChallenge([FromBody]Challenge challenge)
        {
            var challengeId = await _challengeService.CreateChallenge(challenge.CategoryId, challenge.ChallengerId, challenge.OpponentId);
            return Ok(ApiHelper.ResponseWrapper(challengeId));
        }

        #endregion
    }
}
