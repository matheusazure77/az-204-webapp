using domain.DTOs;

namespace sqlapp.Adapters
{
    public interface ISQLFunctionAppAdapter
    {
        Task<ProductDTO> AddProduct(ProductDTO product);
        Task<ProductDTO?> GetProduct(int productId);
        Task<List<ProductDTO>> GetProducts();
        Task<ProductDTO> UpdateProduct(ProductDTO productDTO);
        Task DeleteProduct(int productId);
    }
}