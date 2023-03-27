using domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Applications
{
    public interface ISQLAplication
    {        
        bool IsBeta();
        List<ProductDTO> GetProducts();
        ProductDTO? GetProduct(int productId);
        ProductDTO AddProduct(ProductDTO productDTO);
        ProductDTO UpdateProduct(ProductDTO productDTO);
        void DeleteProduct(int productId);
    }
}
