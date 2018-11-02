using ChallengeIT.Api.Utilities;
using ChallengeIT.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ChallengeIT.Services.Utilities;
using Microsoft.AspNetCore.Cors;

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
        public async Task<IActionResult> CreateChallenge([FromBody]int categoryId, [FromBody]int challengerId, [FromBody]int opponentId)
        {
            var challengeId = await _challengeService.CreateChallenge(categoryId, challengerId, opponentId);
            return Ok(ApiHelper.ResponseWrapper(challengeId));
        }

        #endregion
    }
}
