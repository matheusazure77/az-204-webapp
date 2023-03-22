﻿using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product? GetProduct(int productId);
        void AddProduct(Product product);
    }
}
