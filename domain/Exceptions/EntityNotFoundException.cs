using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Exceptions
{
    public class EntityNotFoundException : ProductApplicationException
    {
        public EntityNotFoundException(string? message) : base(message)
        {
        }
    }
}
