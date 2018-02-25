using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using OrderManagement.Domain;
using RestSharp;

namespace OrderManagement.ApiClient
{
    public sealed class OrderManagementApiClient
    {
        private const string API_BASE = "api/";
        private readonly string _host;

        public OrderManagementApiClient(string host)
        {
            _host = host;
        }

        #region infrastructure

        private bool StatusCodeOk(HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.NoContent;
        }

        private T Execute<T>(string url, Method method = Method.GET) where T : class, new()
        {
            var client = new RestClient(_host);
            var request = new RestRequest(API_BASE + url, method);
            IRestResponse<T> response = client.Execute<T>(request);
            Console.WriteLine(method.ToString() + " " + response.ResponseUri);

            if (response.ErrorException != null || !StatusCodeOk(response.StatusCode))
            {
                string message = $"Error retrieving response. Code: {(int)response.StatusCode}. Content: {response.Content}";
                throw new ApplicationException(message, response.ErrorException);
            }

            return JsonConvert.DeserializeObject<T>(response.Content);
            //return response.Data; // :) left here an hour
        }

        #endregion infrastructure


        public List<Product> GetProducts()
        {
            return Execute<List<Product>>("products");
        }

        public List<Order> GetAllOrders()
        {
            return Execute<List<Order>>("orders");
        }

        public Order GetOrder(Guid id)
        {
            return Execute<Order>($"orders/{id}");
        }

        public Order CreateOrder()
        {
            return Execute<Order>($"orders/", Method.POST);
        }

        public Order AddOrderProduct(Guid orderId, int productId)
        {
            return Execute<Order>($"orders/{orderId}/product/{productId}", Method.POST);
        }

        public Order SetOrderProductQuantity(Guid orderId, int productId, uint quantity)
        {
            return Execute<Order>($"orders/{orderId}/product/{productId}/quantity/{quantity}", Method.PUT);
        }

        public Order ClearOrder(Guid orderId)
        {
            return Execute<Order>($"orders/{orderId}/clear", Method.PUT);
        }

        public Order DeleteOrder(Guid orderId)
        {
            return Execute<Order>($"orders/{orderId}", Method.DELETE);
        }
    }
}
