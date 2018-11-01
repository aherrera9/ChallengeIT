using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeIT.Api.Utilities
{
    public class ApiHelper
    {
        /// <summary>
        /// Wrap the API response so that the data is sent to the consumer in a consistent format
        /// </summary>
        /// <param name="dataToReturn">The data to return to the UI</param>
        /// <param name="statusToReturn">The status of the response</param>
        /// <returns></returns>
        public static object ResponseWrapper(object dataToReturn, object statusToReturn = null)
        {
            return new
            {
                data = dataToReturn,
                status = statusToReturn
            };
        }
    }
}
