using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Data.Contracts
{
    public interface IRankData
    {
        List<string> GetRank(DateTime fromDate, DateTime toDate);    
    }
}
