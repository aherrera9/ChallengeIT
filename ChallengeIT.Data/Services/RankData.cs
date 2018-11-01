using ChallengeIT.Data.Contracts;
using ChallengeIT.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Data.Services
{
    public class RankData : IRankData
    {
        public List<ChallengeResult> GetRank(DateTime fromDate, DateTime toDate)
        {
            List<ChallengeResult> challengeResults = new List<ChallengeResult>();
            DbConnection connection = new DbConnection();
            //using (SqlConnection conn = connection.GetDbConnection())
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();
            using (SqlCommand command = new SqlCommand("GetDetailsForRanking", conn) { CommandType = System.Data.CommandType.StoredProcedure })
            {
                command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = fromDate;
                command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = toDate;
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    challengeResults.Add(new ChallengeResult
                    { ChallengingPlayerId = (int)dataReader.GetValue(0), ChallengerName = (string)dataReader.GetValue(1),
                        OpponentPlayerId = (int)dataReader.GetValue(2), OpponentName = (string)dataReader.GetValue(3),
                        Result = (int)dataReader.GetValue(4), CategoryId = (int)dataReader.GetValue(5)
                    });
                }
                dataReader.Close();
            }            
            return challengeResults;
        }
    }
}
