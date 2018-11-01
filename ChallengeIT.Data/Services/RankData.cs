using ChallengeIT.Data.Contracts;
using ChallengeIT.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Data.Services
{
    internal class RankData : IRankData
    {
        List<ChallengeResult> IRankData.GetRank(DateTime fromDate, DateTime toDate)
        {
            List<ChallengeResult> challengeResults = new List<ChallengeResult>();
            DbConnection connection = new DbConnection();
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();

            SqlCommand command;
            SqlDataReader dataReader;

            command = new SqlCommand("GetDetailsForRanking", conn) { CommandType = System.Data.CommandType.StoredProcedure };
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                challengeResults.Add(new ChallengeResult { ChallengingPlayerId = (int)dataReader.GetValue(0), OpponentPlayerId = (int)dataReader.GetValue(1), Result = (int)dataReader.GetValue(2) });
            }

            dataReader.Close();
            command.Dispose();
            conn.Close();
            return challengeResults;
        }
    }
}
