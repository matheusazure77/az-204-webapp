using domain.Entities;
using domain.Exceptions;
using domain.Repositories;
using infra.Persistence;
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
        private readonly IDAO<Product> _dao;

        public ProductRepository(IDAO<Product> dao)
        {
            _dao = dao;
        }

        public List<Product> GetProducts()
        {  
            string sql = "SELECT ProductID, ProductName, Quantity FROM Products";
            var products = _dao.ExcuteQuery(sql);
            return products;           
                
        }

        public Product? GetProduct(int productId)
        {
            string sql = $"SELECT ProductID, ProductName, Quantity FROM Products WHERE ProductID = @ProductID";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@ProductID", productId);
            var products = _dao.ExcuteQuery(sql, parameters);
            if (products.Any())
            {
                return products.FirstOrDefault();
            }
            return null;
        }

        public Product? GetProductByName(string productName)
        {
            string sql = $"SELECT ProductID, ProductName, Quantity FROM Products WHERE ProductName = @ProductName";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@ProductName", productName);
            var products = _dao.ExcuteQuery(sql, parameters);
            if (products.Any())
            {
                return products.FirstOrDefault();
            }
            return null;
        }

        public Product AddProduct(Product product)
        {
            if(GetProduct(product.ProductID) != null)
            {
                throw new DuplicateEntityException($"There is already a product with this id {product.ProductID}");
            }
            string dml = "INSERT INTO Products (ProductID, ProductName, Quantity) VALUES (@ProductID, @ProductName, @Quantity)";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@ProductID", product.ProductID);
            parameters.Add("@ProductName", product.ProductName);
            parameters.Add("@Quantity", product.Quantity);
            _dao.ExcuteNonQuery(dml, parameters);
            return GetProduct(product.ProductID);
        }


        public Product UpdateProduct(Product product)
        {
            if (GetProduct(product.ProductID) == null)
            {
                throw new EntityNotFoundException($"There is no product with this id {product.ProductID}");
            }
            string dml = "UPDATE Products SET ProductName= @ProductName , Quantity= @Quantity  WHERE ProductID= @ProductID";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@ProductID", product.ProductID);
            parameters.Add("@ProductName", product.ProductName);
            parameters.Add("@Quantity", product.Quantity);
            _dao.ExcuteNonQuery(dml, parameters);
            return GetProduct(product.ProductID);
        }

        public void DeleteProduct(int productId)
        {
            if (GetProduct(productId) == null)
            {
                throw new EntityNotFoundException($"There is no product with this id {productId}");
            }
            string dml = "DELETE FROM Products WHERE ProductID= @ProductID";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@ProductID", productId);
            _dao.ExcuteNonQuery(dml, parameters);
        }
    }
}
