using domain.Entities;

namespace sqlapp.Adapters
{
    public interface ISQLFunctionAppAdapter
    {
        Task<bool> IsBeta();
        Task<List<Product>> GetProducts();
        Task<Product?> GetProduct(int productId);
        void AddProduct(Product product);
    }
}
