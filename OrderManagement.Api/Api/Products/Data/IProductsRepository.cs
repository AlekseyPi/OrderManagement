using System;
using System.Collections.Generic;
using OrderManagement.Domain;

namespace OrderManagement.Api.Data
{
    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
