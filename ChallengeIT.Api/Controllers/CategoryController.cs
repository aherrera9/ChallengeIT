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
    public class CategoryController : ControllerBase
    {
        /// <summary>
        /// Get a list of the categories that are available to challenge on
        /// </summary>
        /// <returns>A list of the categories that are available to challenge on</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var CategoryList = new List<CategoryGet>()
            {
                new CategoryGet() { Id = 1, Name = "Table Tennis" },
                new CategoryGet() { Id = 2, Name = "Pool" },
                new CategoryGet() { Id = 3, Name = "Daytona" }
            };

            return Ok(ApiHelper.ResponseWrapper(CategoryList));
        }
    }
}
