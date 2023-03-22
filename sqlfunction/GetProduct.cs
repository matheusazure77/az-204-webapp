using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using domain.Services;


namespace sqlfunction
{
    public class GetProduct {

        private readonly IProductService _productService;

        public GetProduct(IProductService productService)
        {
            _productService = productService;
        }

        [FunctionName("GetIsBeta")]
        public async Task<IActionResult> RunIsBeta(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var isBeta = _productService.IsBeta().Result;

            return new OkObjectResult(JsonConvert.SerializeObject(isBeta));
        }

        [FunctionName("GetProducts")]
        public async Task<IActionResult> RunProducts(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {           
            var products = _productService.GetProducts();
            return new OkObjectResult(JsonConvert.SerializeObject(products));
        }

        [FunctionName("GetProduct")]
        public async Task<IActionResult> RunProduct(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            int productId = int.Parse(req.Query["productId"]);
            var product = _productService.GetProduct(productId);

            if (product == null )
                return new NotFoundObjectResult($"Product with ProductId {productId} not found");
            var json = JsonConvert.SerializeObject(product);
            return new OkObjectResult(json);
        }
    }
}
