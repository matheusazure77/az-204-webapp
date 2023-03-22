using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using domain.Entities;
using domain.Services;
using sqlapp.Adapters;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISQLFunctionAppAdapter _SQLFunctionAppAdapter;

        public List<Product> Products = new List<Product>();
        public bool IsBeta;

        public IndexModel(ISQLFunctionAppAdapter SQLFunctionAppAdapter)
        {
            _SQLFunctionAppAdapter = SQLFunctionAppAdapter;
        }

        public void OnGet()
        {
            IsBeta = _SQLFunctionAppAdapter.IsBeta().Result;
            Products = _SQLFunctionAppAdapter.GetProducts().GetAwaiter().GetResult();
        }
    }
}