using ChallengeIT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Data.Contracts
{    
    public interface ICategoryData
    {
        List<Category> GetCategories();
    }
}
