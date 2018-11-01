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
    public class CategoryData : ICategoryData
    {
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            DbConnection connection = new DbConnection();
            //using (SqlConnection conn = connection.GetDbConnection())
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();
            using (SqlCommand command = new SqlCommand("GetCategories", conn) { CommandType = System.Data.CommandType.StoredProcedure })
            {
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    categories.Add(new Category { Id = (int)dataReader.GetValue(0), Description = (string)dataReader.GetValue(1) });
                }
                dataReader.Close();
            }
            conn.Close();
            conn.Dispose();
            return categories;
        }       
    }
}
