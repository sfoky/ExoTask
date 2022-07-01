using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace DAL.Services
{
    public class TaskService
    {
        public string ConnectionStringInstance
        {
            get {
                return "server=(localDB)\\TBDemo;database=Exo-01;integrated security=true";
            }
        }
        public IEnumerable<Task> GetAll()
        {
            List<Task> task = new List<Task>();
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Task";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Task taskToAdd = new Task()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        IdCategory = (int)reader["IdCategory"],
                        IdPerson = (int)reader["IdPerson"],
                        Descr = (string)reader["Descr"],
                        CreationDate = (DateTime)reader["CreationDate"],
                        EndingDateMax = (DateTime)reader["EndingDateMax"],
                        EndingDate = reader["EndingDate"] as DateTime? ?? null,
                    };
                    task.Add(taskToAdd);
                }
            }
            return task;
        }

        public Task GetById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Task WHERE Id = @id";
                command.Parameters.AddWithValue("id", Id);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new Task()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    IdCategory = (int)reader["IdCategory"],
                    IdPerson = (int)reader["IdPerson"],
                    Descr = (string)reader["Descr"],
                    CreationDate = (DateTime)reader["CreationDate"],
                    EndingDateMax = (DateTime)reader["EndingDateMax"],
                    EndingDate = reader["EndingDate"] as DateTime? ?? null,
                };

            }
        }
        public IEnumerable<Task> GetByCat(Category category)
        {
            List<Task> task = new List<Task>();
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Task WHERE IdCategory = @idCategory";
                command.Parameters.AddWithValue("idCategory", category.Id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Task taskToAdd = new Task()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        IdCategory = (int)reader["IdCategory"],
                        IdPerson = (int)reader["IdPerson"],
                        Descr = (string)reader["Descr"],
                        CreationDate = (DateTime)reader["CreationDate"],
                        EndingDateMax = (DateTime)reader["EndingDateMax"],
                        EndingDate = reader["EndingDate"] as DateTime? ?? null,
                    };
                    task.Add(taskToAdd);
                }
            }
            return task;
        }

        public IEnumerable<Task> GetByPerson(Person person)
        {
            List<Task> task = new List<Task>();
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {

                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Task WHERE IdPerson = @idPerson";
                command.Parameters.AddWithValue("idPerson", person.Id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Task taskToAdd = new Task()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        IdCategory = (int)reader["IdCategory"],
                        IdPerson = (int)reader["IdPerson"],
                        Descr = (string)reader["Descr"],
                        CreationDate = (DateTime)reader["CreationDate"],
                        EndingDateMax = (DateTime)reader["EndingDateMax"],
                        EndingDate = reader["EndingDate"] as DateTime? ?? null,
                    };
                    task.Add(taskToAdd);
                }
            }
            return task;
        }
        public IEnumerable<Task> GetTasksIncomplete()
        {
            List<Task> task = new List<Task>();
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {

                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Task WHERE EndingDate IS NULL";
                
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Task taskToAdd = new Task()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        IdCategory = (int)reader["IdCategory"],
                        IdPerson = (int)reader["IdPerson"],
                        Descr = (string)reader["Descr"],
                        CreationDate = (DateTime)reader["CreationDate"],
                        EndingDateMax = (DateTime)reader["EndingDateMax"],
                        EndingDate = reader["EndingDate"] as DateTime? ?? null,
                    };
                    task.Add(taskToAdd);
                }
            }
            return task;
        }

        public void AddTask(Task taskToAdd)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO Task ( Name, IdCategory, IdPerson, Descr, CreationDate, EndingDateMax) VALUES(@name, @idCategory, @idPerson, @descr, @creationDate, @endingDateMax,)";
                command.Parameters.AddWithValue("name", taskToAdd.Name);
                command.Parameters.AddWithValue("idCategory", taskToAdd.IdCategory);
                command.Parameters.AddWithValue("idPerson", taskToAdd.IdPerson);
                command.Parameters.AddWithValue("descr", taskToAdd.Descr);
                command.Parameters.AddWithValue("creationDate", taskToAdd.CreationDate);
                command.Parameters.AddWithValue("endingDateMax", taskToAdd.EndingDateMax);
                
                command.ExecuteNonQuery();
            }
        }

        public void UpdateTask(Task taskToUpdate)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE Task SET Name = @name, IdCategory = @idCategory, IdPerson = @idPerson, Descr = @descr, CreationDate = @creationDate, EndingDateMax = @endingDateMax WHERE Id = @id";
                command.Parameters.AddWithValue("name", taskToUpdate.Name);
                command.Parameters.AddWithValue("idCategory", taskToUpdate.IdCategory);
                command.Parameters.AddWithValue("idPerson", taskToUpdate.IdPerson);
                command.Parameters.AddWithValue("descr", taskToUpdate.Descr);
                command.Parameters.AddWithValue("creationDate", taskToUpdate.CreationDate);
                command.Parameters.AddWithValue("endingDateMax", taskToUpdate.EndingDateMax);
                command.Parameters.AddWithValue("id", taskToUpdate.Id);
                command.ExecuteNonQuery();

            }
        }

        public void EndTask(Task endTask)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE Task SET EndingDate = @endingDate WHERE Id = @id";
                command.Parameters.AddWithValue("endingDate", endTask.EndingDate);
                command.Parameters.AddWithValue("id", endTask.Id);
                command.ExecuteNonQuery();
            }
        }

        public int DeleteTask(Task taskToDel)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringInstance))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Task WHERE Id = @id";
                command.Parameters.AddWithValue("id", taskToDel.Id);
                return command.ExecuteNonQuery();
            }
        }


    }
}
