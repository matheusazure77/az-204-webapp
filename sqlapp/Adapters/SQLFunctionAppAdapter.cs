using domain.DTOs;
using domain.Entities;
using System.Text.Json;

namespace sqlapp.Adapters
{
    public class SQLFunctionAppAdapter : ISQLFunctionAppAdapter
    {


        public async Task<ProductDTO?> GetProduct(int productId)
        {
            var functionUrl = "https://appfunctionmatheus.azurewebsites.net/api/GetProduct?code=kF3PsM9BEd3ytCxYAU3afcpgDZGscqUGrSBAMKW6td_XAzFu06Mwhw==";
            //var functionUrl = "http://localhost:7071/api/GetProduct";
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
            var functionUrl = "https://appfunctionmatheus.azurewebsites.net/api/GetProducts?code=MNx3xK-bWfiq2KOFb5a3n5txINZ_-W6-L8aSQwsqyh7yAzFuH_WpDQ==";
            //var functionUrl = "http://localhost:7071/api/GetProducts";
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
            var functionUrl = "https://appfunctionmatheus.azurewebsites.net/api/AddProduct?code=ZfKeY1qCOZTYbWnHlqrSx3wtyNCpjwyMiABVv9HkNPXcAzFuciPVBQ==";
            //var functionUrl = "http://localhost:7071/api/AddProduct";
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
            var functionUrl = "https://appfunctionmatheus.azurewebsites.net/api/UpdateProduct?code=PMXekP7T4r-3rcDll_8OEVoCuFs7Ru9LBuXFPyVnJXJMAzFunFTXVw==";
            //var functionUrl = "http://localhost:7071/api/UpdateProduct";
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
            var functionUrl = "https://appfunctionmatheus.azurewebsites.net/api/DeleteProduct?code=LbCt9cUodhqDHcdiowEY0YKKxc3hlyFpVb_4ec6La_H1AzFunYlHZg==";
            //var functionUrl = "http://localhost:7071/api/DeleteProduct";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(functionUrl + $"?productId={productId}");
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ProductDTO?>(content);
            }
        }
    }
}
