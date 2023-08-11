using AnyCompany.AnyCompany.Data;
using System;
using System.Data.SqlClient;

namespace AnyCompany
{
    public class OrderRepository
    {
        //private static string ConnectionString = @"Data Source=(local);Database=Orders;User Id=admin;Password=password;";

        private readonly DatabaseManager dbManager;

        public OrderRepository(DatabaseManager dbManager)
        {
            this.dbManager = dbManager;
        }
        public int Save(Order order)
        {
            /*SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@OrderId, @Amount, @VAT)", connection);

            command.Parameters.AddWithValue("@OrderId", order.OrderId);
            command.Parameters.AddWithValue("@Amount", order.Amount);
            command.Parameters.AddWithValue("@VAT", order.VAT);

            command.ExecuteNonQuery();

            connection.Close();*/

            string query = "INSERT INTO Orders (Amount, VAT) VALUES (@Amount, @VAT); SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@Amount", order.Amount),
                new SqlParameter("@VAT", order.VAT)
            };

            object result = dbManager.ExecuteScalar(query, parameters);
            int orderId = Convert.ToInt32(result);

            return orderId;
        }
    }
}
