using domain.Entities;
using domain.Services;
using System.Text.Json;

namespace sqlapp.Adapters
{
    public class SQLFunctionAppAdapter : ISQLFunctionAppAdapter
    {
        private readonly IProductService _productService;

        public SQLFunctionAppAdapter(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> IsBeta()
        {
            var functionUrl = "http://localhost:7071/api/GetIsBeta";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(functionUrl);
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<bool>(content);
            }
        }
        public void AddProduct(Product product)
        {
            _productService.AddProduct(product);
        }

        public async Task<Product?> GetProduct(int productId)
        {
            var functionUrl = "https://appfunctionmatheus.azurewebsites.net/api/GetProduct?code=kF3PsM9BEd3ytCxYAU3afcpgDZGscqUGrSBAMKW6td_XAzFu06Mwhw==";
            //var functionUrl = "http://localhost:7071/api/GetProduct";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(functionUrl + $"?productId={productId}");
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Product?>(content);
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            var functionUrl = "https://appfunctionmatheus.azurewebsites.net/api/GetProducts?code=MNx3xK-bWfiq2KOFb5a3n5txINZ_-W6-L8aSQwsqyh7yAzFuH_WpDQ==";
            //var functionUrl = "http://localhost:7071/api/GetProducts";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(functionUrl);
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<Product>>(content);
                return result;
            }
        }
    }
}
