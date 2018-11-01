using ChallengeIT.Data.Contracts;
using ChallengeIT.Services.Contracts;
using ChallengeIT.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Services.Services
{
    public class CategoryService : ICategoryService
    {
        #region Properties

        /// <summary>
        /// The interface for accessing category data
        /// </summary>
        private readonly ICategoryData _CategoryData;

        #endregion
        #region Constructors

        /// <summary>
        /// The constructor for the class
        /// </summary>
        /// <param name="categoryData">The interface for accessing category data</param>
        public CategoryService(ICategoryData categoryData)
        {
            _CategoryData = categoryData;
        }

        #endregion
        #region Methods
        
        /// <summary>
        /// Get a list of categories from the data store
        /// </summary>
        /// <returns>A list of categories</returns>
        public async Task<IEnumerable<Category>> GetCategories()
        {
            List<Category> categories = new List<Category>();

            // get the data from the data store
            var categoriesDate = await Task.Run(() => _CategoryData.GetCategories());

            // convert the data to a service type variable
            foreach(var categoryData in categoriesDate)
            {
                categories.Add(new Category()
                {
                    Id = categoryData.Id,
                    Name = categoryData.Description
                });
            }

            return categories;
        }

        #endregion
    }
}
