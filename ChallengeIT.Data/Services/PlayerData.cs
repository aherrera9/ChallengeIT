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
    public class PlayerData : IPlayerData
    {
        public Player GetPlayerById(int playerId)
        {            
            DbConnection connection = new DbConnection();
            Player player;
            //using (SqlConnection conn = connection.GetDbConnection())
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();
            using (SqlCommand command = new SqlCommand("GetPlayerById", conn) { CommandType = System.Data.CommandType.StoredProcedure })
            {
                command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = playerId;
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                player = new Player() { Name = (string)dataReader.GetValue(0), Email = (string)dataReader.GetValue(1) };
                dataReader.Close();
            }
            conn.Close();
            conn.Dispose();
            return player;
        }

        public List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();
            DbConnection connection = new DbConnection();
            //using (SqlConnection conn = connection.GetDbConnection())
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();
            using (SqlCommand command = new SqlCommand("GetPlayers", conn) { CommandType = System.Data.CommandType.StoredProcedure })
            {
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    players.Add(new Player { Id = (int)dataReader.GetValue(0), Name = (string)dataReader.GetValue(1) });
                }
                dataReader.Close();
            }
            conn.Close();
            conn.Dispose();
            return players;
        }
    }
}
