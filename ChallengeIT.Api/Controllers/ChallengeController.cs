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

        [HttpGet]
        [Route("IsChallengeAccepted")]
        public async Task<IActionResult> IsChallengeAccepted()
        {
            return Ok(ApiHelper.ResponseWrapper(Enums.ChallengeStatus.Waiting));
        }

        [HttpPost]
        [Route("SetChallengeResult")]
        public async Task<IActionResult> SetChallengeResult([FromBody]int result)
        {
            return Ok();
        }

        [HttpPost]
        [Route("ActionChallenge")]
        public async Task<IActionResult> ActionChallenge([FromBody]int action)
        {
            return Ok();
        }

        #endregion
    }
}
