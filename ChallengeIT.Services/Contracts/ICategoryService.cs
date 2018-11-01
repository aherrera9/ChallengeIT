using ChallengeIT.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Services.Contracts
{
    public interface ICategoryService
    {
        /// <summary>
        /// Get a list of categories from the data store
        /// </summary>
        /// <returns>A list of categories</returns>
        Task<IEnumerable<Category>> GetCategories();
    }
}
