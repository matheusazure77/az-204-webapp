using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Exceptions
{
    public class ProductApplicationException: Exception
    {
        public ProductApplicationException(string? message) : base(message)
        {
        }
    }
}
