using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using domain.Applications;
using domain.Exceptions;

namespace sqlfunction
{
    public class DeleteProduct
    {
        private readonly ISQLAplication _SQLAplication;

        public DeleteProduct(ISQLAplication SQLAplication)
        {
            _SQLAplication = SQLAplication;
        }
        [FunctionName("DeleteProduct")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = null)] HttpRequest req,
            ILogger log)
        {
            int productId = int.Parse(req.Query["productId"]);
            
            try
            {
                _SQLAplication.DeleteProduct(productId);
            }            
            catch (ProductApplicationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch(Exception ex) {
                return new BadRequestObjectResult(ex);
            }

            return new OkResult();
        }
    }
}
