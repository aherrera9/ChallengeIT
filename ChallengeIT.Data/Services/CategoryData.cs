﻿using ChallengeIT.Data.Contracts;
using ChallengeIT.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Data.Services
{
    internal class CategoryData : ICategoryData
    {
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            DbConnection connection = new DbConnection();
            SqlConnection conn = connection.GetDbConnection();
            conn.Open();

            SqlCommand command;
            SqlDataReader dataReader;

            command = new SqlCommand("GetCategories", conn) { CommandType = System.Data.CommandType.StoredProcedure };
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                categories.Add(new Category {Id = (int)dataReader.GetValue(0), Description = (string)dataReader.GetValue(1) });                
            }
                        
            dataReader.Close();
            command.Dispose();
            conn.Close();
            return categories;
        }       
    }
}
