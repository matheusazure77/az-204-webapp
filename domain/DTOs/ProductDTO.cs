﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.DTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
