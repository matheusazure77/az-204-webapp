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
using domain.Applications;

namespace sqlfunction
{
    public class GetProduct {

        private readonly ISQLAplication _SQLAplication;

        public GetProduct(ISQLAplication SQLAplication)
        {
            _SQLAplication = SQLAplication;
        }

        [FunctionName("GetProducts")]
        public async Task<IActionResult> RunProducts(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {           
            var products = _SQLAplication.GetProducts();
            return new OkObjectResult(JsonConvert.SerializeObject(products));
        }

        [FunctionName("GetProduct")]
        public async Task<IActionResult> RunProduct(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            int productId = int.Parse(req.Query["productId"]);
            var product = _SQLAplication.GetProduct(productId);

            if (product == null )
                return new NotFoundObjectResult($"Product with ProductId {productId} not found");
            var json = JsonConvert.SerializeObject(product);
            return new OkObjectResult(json);
        }
    }
}
