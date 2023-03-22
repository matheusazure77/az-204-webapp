using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using domain.Entities;
using domain.Services;
using domain.Repositories;

namespace infra.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFeatureManager _featureManager;

        public ProductService(IProductRepository productRepository, IFeatureManager featureManager)
        {            
            _featureManager = featureManager;
            _productRepository = productRepository;
        }

        public async Task<bool> IsBeta()
        {
            if (await _featureManager.IsEnabledAsync("beta"))
            {
                return true;
            }
            return false;
        }

        public List<Product> GetProducts()
        {            
            return _productRepository.GetProducts();
        }

        public Product? GetProduct(int productId)
        {
            return _productRepository.GetProduct(productId);
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }
    }
}
