using ChallengeIT.Api.Models;
using ChallengeIT.Api.Utilities;
using ChallengeIT.Services.Contracts;
using ChallengeIT.Services.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeIT.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Properties

        private readonly ICategoryService _categoryService;

        #endregion
        #region Controller

        /// <summary>
        /// The controller for the class
        /// </summary>
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        #endregion
        #region Methods

        /// <summary>
        /// Get a list of the categories that are available to challenge on
        /// </summary>
        /// <returns>A list of the categories that are available to challenge on</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetCategories();

            var categoryGets = new List<CategoryGet>();
            foreach (var category in categories)
            {
                categoryGets.Add(new CategoryGet()
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }

            return Ok(ApiHelper.ResponseWrapper(categoryGets));
        }

        #endregion
    }
}
