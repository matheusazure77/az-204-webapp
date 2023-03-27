using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using domain.Applications;
using domain.DTOs;
using sqlapp.Adapters;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISQLAplication _SQLAplication;
        private readonly ISQLFunctionAppAdapter _SQLFunctionAppAdapter;

        public List<ProductDTO> Products = new List<ProductDTO>();
        public bool IsBeta;

        public IndexModel(ISQLAplication SQLAplication, ISQLFunctionAppAdapter sQLFunctionAppAdapter = null)
        {
            _SQLAplication = SQLAplication;
            _SQLFunctionAppAdapter = sQLFunctionAppAdapter;
        }

        public void OnGet()
        {
            IsBeta = _SQLAplication.IsBeta();
            Products = _SQLFunctionAppAdapter.GetProducts().Result;
        }
    }
}