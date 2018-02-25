using System;
namespace OrderManagement.Domain
{
    public sealed class OrderItem
    {
        public Product Product { get; set; }
        public UInt32 Quantity { get; set; }
    }
}
