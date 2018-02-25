using System;
using System.Collections.Generic;
using OrderManagement.Domain;

namespace OrderManagement.Api.Data
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> GetAll();
        Order Create();
        Order Get(Guid id);
        Order Update(Order order);
        Order Delete(Guid id);
    }
}
