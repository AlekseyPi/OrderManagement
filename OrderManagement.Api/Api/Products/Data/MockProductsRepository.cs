using System;
using System.Collections.Generic;
using OrderManagement.Domain;

namespace OrderManagement.Api.Data.Implementation
{
    public sealed class MockProductsRepository : IProductsRepository
    {
        public IEnumerable<Product> Products => new List<Product>() {
            new Product() {Id = 1, Name = "First product"},
            new Product() {Id = 2, Name = "Second product"},
            new Product() {Id = 3, Name = "Third product"},
            new Product() {Id = 4, Name = "4th product"},
            new Product() {Id = 5, Name = "5th product"},
        };
    }
}
