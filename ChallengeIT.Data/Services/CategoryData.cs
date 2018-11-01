using ChallengeIT.Data.Contracts;
using ChallengeIT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Data.Services
{
    internal class CategoryData : ICategoryData
    {
        public List<Category> GetCategories()
        {
            return new List<Category>();

            // Your database code goes here
        }
       
    }
}
