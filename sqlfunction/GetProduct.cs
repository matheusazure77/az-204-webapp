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

        [FunctionName("GetProduct")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {           
            var products = _productService.GetProducts();
            return new OkObjectResult(products);
        }
    }
}
