using Microsoft.Data.SqlClient;
using Microsoft.FeatureManagement;
using sqlapp.Models;

namespace sqlapp.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly IFeatureManager _featureManager;

        public ProductService(IConfiguration configuration, IFeatureManager featureManager)
        {
            _configuration = configuration;
            _featureManager = featureManager;
        }

        public async Task<bool> IsBeta()
        {
            if (await _featureManager.IsEnabledAsync("beta"))
            {
                return true;
            }
            return false;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration["SQLConnection"]);
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
