using domain.Entities;

namespace domain.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProduct(int productId);
        Task<bool> IsBeta();
        void AddProduct(Product product);
    }
}