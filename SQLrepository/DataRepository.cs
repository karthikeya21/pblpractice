using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Microsoft.Data.SqlClient;

namespace SQLrepository
{
    public class DataRepository : IDataRepository
    {
        private readonly string[] studentNames = new[]
        {
        "John","Jane","Alice","Bob","Eve","Karthik","Supreeth","Ajay","Abhiram","Babu","Candice"
        };

        public string[] GetData()
        {
            return studentNames;
        }
        private readonly IDbConnection _connection;
        public DataRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<Student>> GetAll()
        {
            List<Student> students = new List<Student>();

            _connection.Open();
            string query = "select * from students";

            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Student student = new Student()
                    {
                        id = Convert.ToInt32(reader["sid"]),
                        name = Convert.ToString(reader["sname"])


                    };
                    students.Add(student);
                }
            }
            _connection.Close();
            return students;
        }
        public async Task Insert(Student student)
        {
            _connection.Open();
            string query = "INSERT INTO students (sid,sname) VALUES (@sid,@sname)";

            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@sid", student.id);
            command.Parameters.AddWithValue("@sname", student.name);

            await command.ExecuteNonQueryAsync();
            _connection.Close();
        }
        public async Task Update(Student student)
        {
            _connection.Open();
            string query = "UPDATE students SET sname=@sname where sid=@sid";

            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@sid", student.id);
            command.Parameters.AddWithValue("@sname", student.name);

            await command.ExecuteNonQueryAsync();
            _connection.Close();
        }
        public async Task Delete(int id)
        {
            _connection.Open();
            string query = "DELETE FROM students where sid=@sid";

            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@sid", id);

            await command.ExecuteNonQueryAsync();
            _connection.Close();
        }
    }
}
