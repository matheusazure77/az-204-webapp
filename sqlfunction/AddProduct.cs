using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using domain.Exceptions;
using domain.DTOs;
using domain.Applications;

namespace sqlfunction
{
    public class AddProduct
    {
        private readonly ISQLAplication _SQLAplication;

        public AddProduct(ISQLAplication SQLAplication)
        {
            _SQLAplication = SQLAplication;
        }
        [FunctionName("AddProduct")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            ProductDTO productDTO = JsonConvert.DeserializeObject<ProductDTO>(requestBody);
            try
            {
                productDTO = _SQLAplication.AddProduct(productDTO);
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

            return new OkObjectResult(productDTO);
        }
    }
}
