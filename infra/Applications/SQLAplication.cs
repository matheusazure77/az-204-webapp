using domain.Applications;
using domain.DTOs;
using domain.Entities;
using domain.Services;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.Applications
{
    public class SQLAplication: ISQLAplication
    {
        private readonly IFeatureManager _featureManager;
        private readonly IProductService _productService;

        public SQLAplication(IFeatureManager featureManager, IProductService productService)
        {
            _featureManager = featureManager;
            _productService = productService;
        }

        public bool IsBeta()
        {
            if (_featureManager.IsEnabledAsync("beta").GetAwaiter().GetResult())
            {
                return true;
            }
            return false;
        }

        public ProductDTO? GetProduct(int productId)
        {
            Product? product = _productService.GetProduct(productId);
            if(product == null)
            {
                return null;
            }
            return new ProductDTO { 
                ProductID = productId, 
                ProductName=product.ProductName, 
                Quantity=product.Quantity 
            };
        }

        public  List<ProductDTO> GetProducts()
        {
            return _productService.GetProducts()
                .Select(product => new ProductDTO { 
                    ProductID = product.ProductID, 
                    ProductName = product.ProductName, 
                    Quantity = product.Quantity 
                })
                .ToList();
        }

        public ProductDTO AddProduct(ProductDTO productDTO)
        {
            Product product = new Product
            {
                ProductID = productDTO.ProductID,
                ProductName = productDTO.ProductName,
                Quantity = productDTO.Quantity
            };
            product = _productService.AddProduct(product);
            return new ProductDTO
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Quantity = product.Quantity
            };
        }

        public ProductDTO UpdateProduct(ProductDTO productDTO)
        {
            Product product = new Product
            {
                ProductID = productDTO.ProductID,
                ProductName = productDTO.ProductName,
                Quantity = productDTO.Quantity
            };
            product = _productService.UpdateProduct(product);
            return new ProductDTO
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Quantity = product.Quantity
            };
        }

        public void DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
        }
    }
}
