using domain.Entities;

namespace domain.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Task<bool> IsBeta();
    }
}