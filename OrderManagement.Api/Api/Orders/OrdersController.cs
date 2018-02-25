using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Api.Data;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain;

namespace OrderManagement.Api.Api.Orders
{
    [Route("api/[controller]")]
    public sealed class OrdersController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IProductsRepository _productsRepository;

        public OrdersController(
            IOrdersRepository ordersRepository,
            IProductsRepository productsRepository)
        {
            _ordersRepository = ordersRepository;
            _productsRepository = productsRepository;
        }

        //! for test purposes
        // curl 'localhost:5000/api/orders'
        [HttpGet]
        public JsonResult GetAll()
        {
            var allOrders = _ordersRepository.GetAll();
            return Json(allOrders);
        }

        // curl -XPOST 'localhost:5000/api/orders' -d ''
        [HttpPost]
        public JsonResult Create()
        {
            var order = _ordersRepository.Create();
            return Json(order);
        }

        // curl 'localhost:5000/api/orders/fa1e8f3b-a902-4845-96d2-294678685f98'
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var order = _ordersRepository.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // curl -XDELETE 'localhost:5000/api/orders/fa1e8f3b-a902-4845-96d2-294678685f98'
        [HttpDelete("{orderId}")]
        public IActionResult Delete(Guid orderId)
        {
            var deletedOrder = _ordersRepository.Delete(orderId);
            return deletedOrder == null ? (IActionResult)NotFound("Order not found") : NoContent();
        }
       
        // curl -XPUT 'localhost:5000/api/orders/fa1e8f3b-a902-4845-96d2-294678685f98/clear' -d ''
        [HttpPut("{orderId}/clear")]
        public IActionResult ClearOrder(Guid orderId)
        {
            Order order = _ordersRepository.Get(orderId);
            if (order == null)
            {
                return NotFound("Order not found");
            }

            order.OrderItems.Clear();
            order = _ordersRepository.Update(order);

            return Json(order);
        }

        // remove all items of this product: 
        // curl -XPUT 'localhost:5000/api/orders/fa1e8f3b-a902-4845-96d2-294678685f98/product/2/quantity/0' -d ''

        // set item quantity: 
        // curl -XPUT 'localhost:5000/api/orders/fa1e8f3b-a902-4845-96d2-294678685f98/product/2/quantity/17' -d ''
        [HttpPut("{orderId}/product/{productId}/quantity/{quantity}")]
        public IActionResult SetOrderProductQuantity(Guid orderId, int productId, uint quantity)
        {
            Order order = _ordersRepository.Get(orderId);
            if (order == null)
            {
                return NotFound("Order not found");
            }

            var orderItem = order.OrderItems.FirstOrDefault(x => x.Product.Id == productId);
            if (orderItem == null)
            {
                var product = _productsRepository.Products.FirstOrDefault(x => x.Id == productId);
                if (product == null)
                {
                    return NotFound("Product not found");
                }

                if (quantity > 0)
                {
                    order.OrderItems.Add(new OrderItem() { Product = product, Quantity = quantity });
                }
            }
            else
            {
                if (quantity == 0)
                {
                    order.OrderItems.Remove(orderItem);
                }
                else
                {
                    orderItem.Quantity = quantity;
                }
            }

            order = _ordersRepository.Update(order);

            return Json(order);
        }

        // add yet another item (or first): 
        // curl -XPOST 'localhost:5000/api/orders/fa1e8f3b-a902-4845-96d2-294678685f98/product/2' -d ''
        [HttpPost("{orderId}/product/{productId}")]
        public IActionResult AddOrderProduct(Guid orderId, int productId)
        {
            Order order = _ordersRepository.Get(orderId);
            if (order == null)
            {
                return NotFound("Order not found");
            }

            var orderItem = order.OrderItems.FirstOrDefault(x => x.Product.Id == productId);
            if (orderItem == null)
            {
                var product = _productsRepository.Products.Single(x => x.Id == productId);
                if (product == null)
                {
                    return NotFound("Product not found");
                }

                order.OrderItems.Add(new OrderItem() { Product = product, Quantity = 1 });
            }
            else
            {
                orderItem.Quantity = orderItem.Quantity + 1;
            }

            order = _ordersRepository.Update(order);

            return Json(order);
        }

    }
}
