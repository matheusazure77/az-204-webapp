using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using domain.DTOs;
using domain.Applications;
using domain.Exceptions;

namespace sqlfunction
{
    public class UpdateProduct
    {
        private readonly ISQLAplication _SQLAplication;

        public UpdateProduct(ISQLAplication SQLAplication)
        {
            _SQLAplication = SQLAplication;
        }
        [FunctionName("UpdateProduct")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            ProductDTO dto = JsonConvert.DeserializeObject<ProductDTO>(requestBody);
            ProductDTO product;
            try
            {
                product = _SQLAplication.UpdateProduct(dto);
            }
            catch (DuplicateEntityException ex)
            {
                return new ConflictObjectResult(ex.Message);
            }
            catch (ProductApplicationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }


            return new OkObjectResult(product);
        }
    }
}
