using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using domain.Entities;
using domain.Services;

namespace sqlfunction
{
    public class AddProduct
    {
        private readonly IProductService _productService;

        public AddProduct(IProductService productService)
        {
            _productService = productService;
        }
        [FunctionName("AddProduct")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Product product = JsonConvert.DeserializeObject<Product>(requestBody);
            _productService.AddProduct(product);

            if (product == null)
                return new ConflictObjectResult($"Product with ProductId {product.ProductID} already exists");

            return new OkObjectResult(product);
        }
    }
}
