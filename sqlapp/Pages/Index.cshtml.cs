using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using domain.Entities;
using domain.Services;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public List<Product> Products = new List<Product>();
        public bool IsBeta;

        public IndexModel(IProductService productService)
        {
           _productService = productService;
        }

        public void OnGet()
        {
            IsBeta = _productService.IsBeta().Result;
            Products = _productService.GetProducts();
        }
    }
}