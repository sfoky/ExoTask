using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Services
{
    public class CategoryService
    {
        public string ConnectionStringInstance
        {
            get {
                return "server=(localDB)\\TBDemo;database=Exo-01;integrated security=true";
            }
        }

        public IEnumerable<Category> GetAll()
        {
            List<Category> category = new List<Category>();
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Category";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category categoryToAdd = new Category()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"]
                    };
                    category.Add(categoryToAdd);
                }
            }
            return category;
        }

        public Category GetById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Category WHERE Id = @id";
                command.Parameters.AddWithValue("id", Id);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new Category()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"]
                };
                
            }
        }

        public int AddCategory(Category categoryToADD)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO Category ( Name) VALUES(@name)";
                command.Parameters.AddWithValue("name", categoryToADD.Name);
                return command.ExecuteNonQuery();
            
            }
        }

        public int DeleteCategory(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Category WHERE Id = @id";
                command.Parameters.AddWithValue("id", Id);
                return command.ExecuteNonQuery();
            }
        }


    }
}
