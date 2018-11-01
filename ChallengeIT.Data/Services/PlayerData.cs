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
    internal class PlayerData : IPlayerData
    {
        public Player GetPlayerById(int playerId)
        {            
            DbConnection connection = new DbConnection();
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();

            SqlCommand command;
            SqlDataReader dataReader;

            command = new SqlCommand("GetPlayerEmail", conn) { CommandType = System.Data.CommandType.StoredProcedure };
            dataReader = command.ExecuteReader();
            dataReader.Read();
            Player player = new Player() { Name = (string)dataReader.GetValue(0), Email = (string)dataReader.GetValue(1) };            

            dataReader.Close();
            command.Dispose();
            conn.Close();
            return player;
        }

        public List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();
            DbConnection connection = new DbConnection();
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();

            SqlCommand command;
            SqlDataReader dataReader;

            command = new SqlCommand("GetPlayers", conn) { CommandType = System.Data.CommandType.StoredProcedure };
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                players.Add(new Player { Id = (int)dataReader.GetValue(0), Name = (string)dataReader.GetValue(1) });
            }

            dataReader.Close();
            command.Dispose();
            conn.Close();
            return players;
        }
    }
}
