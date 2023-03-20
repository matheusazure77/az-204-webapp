using Microsoft.Data.SqlClient;
using sqlapp.Models;

namespace sqlapp.Services
{
    public class ProductService
    {
        public static string db_source = "appservermatheus.database.windows.net";
        public static string db_user = "sqluser";
        public static string db_password = "1vT!KP)99?nhjkl90";
        public static string db_database = "appdb";

        public SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            var products = new List<Product>();
            string sql = "SELECT ProductID, ProductName, Quantity FROM Products";
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    products.Add(product);
                }
            }
            conn.Close();
            return products;
        }

    }
}
