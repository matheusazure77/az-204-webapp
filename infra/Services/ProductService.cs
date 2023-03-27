using domain.Entities;
using domain.Services;
using domain.Repositories;
using domain.Exceptions;

namespace infra.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {            
           _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {            
            return _productRepository.GetProducts();
        }

        public Product? GetProduct(int productId)
        {
            return _productRepository.GetProduct(productId);
        }

        public Product AddProduct(Product product)
        {
            Product? productsWithName = _productRepository.GetProductByName(product.ProductName);
            if (productsWithName != null && !productsWithName.ProductID.Equals(product.ProductID))
                throw new DuplicateEntityException($"There is alredy another product with the same name: {product.ProductName}");
            return _productRepository.AddProduct(product);
        }

        public Product UpdateProduct(Product product)        {
            
            Product? productsWithName = _productRepository.GetProductByName(product.ProductName);
            if (productsWithName != null && !productsWithName.ProductID.Equals(product.ProductID))
                throw new DuplicateEntityException($"There is alredy another product with the same name: {product.ProductName}");
                      
            return _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }
    }
}
