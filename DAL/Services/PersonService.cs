using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Services
{
    public class PersonService
    {
        public string ConnectionStringInstance
        {
            get 
            {
                return "server=(localDB)\\TBDemo;database=Exo-01;integrated security=true";
            }
        }
        public IEnumerable<Person> GetAll()
        {
            List<Person> Person = new List<Person>();
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Person";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Person PersonToAdd = new Person()
                    {
                        Id = (int)reader["Id"],
                        LastName = (string)reader["LastName"],
                        FirstName = (string)reader["FirstName"],
                    };
                    Person.Add(PersonToAdd);
                }
            }
            return Person;
        }

        public Person GetById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Person WHERE Id = @id";
                command.Parameters.AddWithValue("id", Id);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new Person()
                {
                    Id = (int)reader["Id"],
                    LastName = (string)reader["LastName"],
                    FirstName = (string)reader["FirstName"],
                };

            }
        }

        public int AddPerson(Person PersonToADD)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO Person ( LastName, FirstName) VALUES(@lastName,@firstName)";
                command.Parameters.AddWithValue("lastName", PersonToADD.LastName);
                command.Parameters.AddWithValue("firstName", PersonToADD.FirstName);
                return command.ExecuteNonQuery();

            }
        }

        public int DeletePerson(Person personToDel)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Person WHERE Id = @id";
                command.Parameters.AddWithValue("id", personToDel.Id);
                return command.ExecuteNonQuery();
            }
        }

        public void UpdatePerson(Person personToUpdate)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE Person SET LastName = @lastName, FirstName = @firstName Where Id = @id" ;
                command.Parameters.AddWithValue("lastName", personToUpdate.LastName);
                command.Parameters.AddWithValue("firstName", personToUpdate.FirstName);
                command.Parameters.AddWithValue("id", personToUpdate.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}
