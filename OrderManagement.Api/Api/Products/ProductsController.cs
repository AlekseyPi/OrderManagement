using System;
using System.Collections.Generic;
using OrderManagement.Api.Data;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain;

namespace OrderManagement.Api.Api.Products
{
    [Route("api/[controller]")]
    public sealed class ProductsController
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        // curl 'localhost:5000/api/products'
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _productsRepository.Products;
        }
    }
}
