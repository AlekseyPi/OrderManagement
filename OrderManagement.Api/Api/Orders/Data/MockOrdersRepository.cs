using System;
using System.Collections.Generic;
using System.Linq;
using OrderManagement.Domain;

namespace OrderManagement.Api.Data.Implementation
{
    public sealed class MockOrdersRepository : IOrdersRepository
    {
        private List<Order> _orders = new List<Order>();

        private IProductsRepository _productsRepository;

        public MockOrdersRepository(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        //! for test purposes
        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }

        public Order Delete(Guid id)
        {
            var order = _orders.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                _orders.Remove(order);
            }
            return order;
        }

        public Order Get(Guid id)
        {
            return _orders.SingleOrDefault(x => x.Id == id);
        }

        public Order Update(Order order)
        {
            var existedOrder = _orders.Single(x => x.Id == order.Id);
            _orders.Remove(existedOrder);
            _orders.Add(order);
            return order;
        }

        public Order Create()
        {
            var order = new Order() { Id = Guid.NewGuid() };
            _orders.Add(order);
            return order;
        }

    }
}
