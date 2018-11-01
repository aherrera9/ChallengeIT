using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeIT.Services.Models
{
    public class Category
    {
        /// <summary>
        /// The unique identifier for the category
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the category
        /// </summary>
        public string Name { get; set; }
    }
}
