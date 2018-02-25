using System;
using System.Collections.Generic;

namespace OrderManagement.Domain
{
    public sealed class Order
    {
        public Guid Id { get; set; }

        public List<OrderItem> OrderItems { get; } = new List<OrderItem>();
    }
}
