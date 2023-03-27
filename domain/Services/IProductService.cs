using domain.Entities;

namespace domain.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProduct(int productId);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}