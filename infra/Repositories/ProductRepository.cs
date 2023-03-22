﻿using domain.Entities;
using domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration["SQLConnection"]);
        }

        public List<Product> GetProducts()
        {
            using (SqlConnection conn = GetConnection()) {
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

        public Product? GetProduct(int productId)
        {
            using (SqlConnection conn = GetConnection())
            {
                var products = new List<Product>();
                string sql = $"SELECT ProductID, ProductName, Quantity FROM Products WHERE ProductID = {productId}";
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                Product? product = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {                    
                    while (reader.Read())
                    {
                        product = new Product()
                        {
                            ProductID = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Quantity = reader.GetInt32(2)
                        };                        
                    }
                }
                conn.Close();
                return product;
            }
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection conn = GetConnection())
            {
                string insertStatement = "INSERT INTO Products (ProductID, ProductName, Quantity) VALUES (@ProductID, @ProductName, @Quantity)";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(insertStatement, conn))
                {
                    cmd.Parameters.Add("@ProductID", System.Data.SqlDbType.Int).Value = product.ProductID;
                    cmd.Parameters.Add("@ProductName", System.Data.SqlDbType.VarChar, 1000).Value = product.ProductName;
                    cmd.Parameters.Add("@Quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                
                conn.Close();
            }
        }
    }
}
