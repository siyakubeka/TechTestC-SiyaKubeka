using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.AnyCompany.Data
{
    public class DatabaseManager
    {
        private readonly string connectionString;

        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlDataReader ExecuteReader(string query, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);

            return command.ExecuteReader();
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);

            int result = command.ExecuteNonQuery();
            connection.Close();

            return result;
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);

            object result = command.ExecuteScalar();
            connection.Close();

            return result;
        }

    }
}
