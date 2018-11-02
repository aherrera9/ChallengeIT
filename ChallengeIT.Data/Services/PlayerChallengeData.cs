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
    public class PlayerChallengeData : IPlayerChallengeData
    {
        public void CancelChallenge(int challengeId)
        {
            DbConnection connection = new DbConnection();
            //using (SqlConnection conn = connection.GetDbConnection())
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();
            using (SqlCommand command = new SqlCommand("CancelChallenge", conn) { CommandType = System.Data.CommandType.StoredProcedure })
            {
                command.Parameters.Add("@ChallengeId", SqlDbType.Int).Value = challengeId;
                int noOfRowsAffected = command.ExecuteNonQuery();
            }
            conn.Close();
            conn.Dispose();
        }

        public PlayerChallenge GetChallenge(int challengeId)
        {            
            DbConnection connection = new DbConnection();
            PlayerChallenge challenge;
            //using (SqlConnection conn = connection.GetDbConnection())
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();
            using (SqlCommand command = new SqlCommand("GetChallenge", conn) { CommandType = System.Data.CommandType.StoredProcedure })
            {
                SqlDataReader dataReader;
                command.Parameters.Add("@ChallengeId", SqlDbType.Int).Value = challengeId;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                challenge = new PlayerChallenge { ChallengingPlayerId = (int)dataReader.GetValue(0), OpponentPlayerId = (int)dataReader.GetValue(1), ChallengeDate = (DateTime)dataReader.GetValue(2), ChallengeStatus = (int)dataReader.GetValue(3) };
                dataReader.Close();
            }
            conn.Close();
            conn.Dispose();
            return challenge;
        }

        public PendingChallenge GetPendingChallengeByUser(int playerId)
        {
            DbConnection connection = new DbConnection();
            PendingChallenge pendingChallenge;
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();
            using (SqlCommand command = new SqlCommand("PendingChallengeByUser", conn) { CommandType = System.Data.CommandType.StoredProcedure })
            {
                SqlDataReader dataReader;
                command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = playerId;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                pendingChallenge = new PendingChallenge {ChallengeId = (int)dataReader.GetValue(0), ChallengingPlayerId = (int)dataReader.GetValue(1), OpponentPlayerId = (int)dataReader.GetValue(2) };
                dataReader.Close();
            }
            conn.Close();
            conn.Dispose();
            return pendingChallenge;
        }

        public int NewChallenge(int challengingPlayerId, int opponentPlayerId, int categoryId)
        {
            DbConnection connection = new DbConnection();
            int challengeId;

            //using (SqlConnection conn = connection.GetDbConnection())
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();
            using (SqlCommand command = new SqlCommand("CreateNewChallenge", conn) { CommandType = System.Data.CommandType.StoredProcedure })
            {
                SqlDataReader dataReader;

                command.Parameters.Add("@ChallengingPlayerId", SqlDbType.Int).Value = challengingPlayerId;
                command.Parameters.Add("@OpponentPlayerId", SqlDbType.Int).Value = opponentPlayerId;
                command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                challengeId = (int)dataReader.GetValue(0);
                dataReader.Close();
            }
            conn.Close();
            conn.Dispose();
            return challengeId;
        }

        public void UpdateChallenge(int challengeId, int challengeResponse)
        {
            DbConnection connection = new DbConnection();
            //using (SqlConnection conn = connection.GetDbConnection())
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();
            using (SqlCommand command = new SqlCommand("UpdateChallenge", conn) { CommandType = System.Data.CommandType.StoredProcedure })
            {
                command.Parameters.Add("@ChallengeId", SqlDbType.Int).Value = challengeId;
                command.Parameters.Add("@Response", SqlDbType.Int).Value = challengeResponse;
                int noOfRowsAffected = command.ExecuteNonQuery();
            }
            conn.Close();
            conn.Dispose();
        }
    }
}
