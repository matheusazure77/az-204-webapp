using domain.DTOs;
using domain.Entities;
using System.Text.Json;

namespace sqlapp.Adapters
{
    public class SQLFunctionAppAdapter : ISQLFunctionAppAdapter
    {

        private readonly IConfiguration _config;

        public SQLFunctionAppAdapter(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ProductDTO?> GetProduct(int productId)
        {
            var functionUrl = _config["url-function-app-get-product"];
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(functionUrl + $"?productId={productId}");
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ProductDTO?>(content);
                return result;
            }
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            var functionUrl = _config["url-function-app-get-products"];
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(functionUrl);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ProductDTO>>(content);
                return result;
            }
        }

        public async Task<ProductDTO> AddProduct(ProductDTO productDTO)
        {
            var functionUrl = _config["url-function-app-add-product"];
            using (HttpClient client = new HttpClient())
            {                
                HttpResponseMessage response = await client.PostAsJsonAsync(functionUrl, productDTO);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ProductDTO?>(content);
                return result;
            }
        }
        
        public async Task<ProductDTO> UpdateProduct(ProductDTO productDTO)
        {
            var functionUrl = _config["url-function-app-update-product"];
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(functionUrl, productDTO);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ProductDTO?>(content);
                return result;
            }
        }

        public async Task DeleteProduct(int productId)
        {
            var functionUrl = _config["url-function-app-delete-product"];
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(functionUrl + $"?productId={productId}");
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ProductDTO?>(content);
            }
        }
    }
}
