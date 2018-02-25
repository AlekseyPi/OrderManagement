using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OrderManagement.ApiClient;
using OrderManagement.Domain;

namespace OrderManagement.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Log("Client app started...");
            Order apiOrder = new Order();
            List<Product> apiProducts = null;

            var apiClient = new OrderManagementApiClient("http://localhost:5000");

            Log("Request all products", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiProducts = apiClient.GetProducts()));

            Log("Request all orders", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.GetAllOrders()));

            Log("Request nonexistent order", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.GetOrder(Guid.Empty)));

            Log("Create 3 orders", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.CreateOrder()));
            Log(Environment.NewLine, WrapExeptions(() => apiClient.CreateOrder()));
            Log(Environment.NewLine, WrapExeptions(() => apiOrder = apiClient.CreateOrder()));

            Log("Request all orders", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.GetAllOrders()));

            Log("Add product #3 to order", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.AddOrderProduct(apiOrder.Id, apiProducts[2].Id)));

            Log("Add product #2 to order", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.AddOrderProduct(apiOrder.Id, apiProducts[1].Id)));

            Log("Set product #2 quantity to 43", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.SetOrderProductQuantity(apiOrder.Id, apiProducts[1].Id, 43)));

            Log("Set product #5 quantity to 17", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.SetOrderProductQuantity(apiOrder.Id, apiProducts[4].Id, 17)));

            Log("Set non existant order some existant product quantity", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.SetOrderProductQuantity(Guid.Empty, 1, 1)));

            Log("Set non existant product with id=77 quantity to 3", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.SetOrderProductQuantity(apiOrder.Id, 77, 3)));

            Log("Set product quantity to 0 (remove from order)", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.SetOrderProductQuantity(apiOrder.Id, apiProducts[1].Id, 0)));

            Log("Clear order", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.ClearOrder(apiOrder.Id)));

            Log("Delete order", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.DeleteOrder(apiOrder.Id)));

            Log("Delete nonexistant order", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.DeleteOrder(apiOrder.Id)));


            Log("Request all orders", color: ConsoleColor.Green);
            Log(Environment.NewLine, WrapExeptions(() => apiClient.GetAllOrders()));


            Console.ReadLine();
        }

        static void Log(string message, object data = null, ConsoleColor? color = null)
        {
            var dataString = data == null ? String.Empty : Environment.NewLine + JsonConvert.SerializeObject(data, Formatting.Indented);

            var savedColor = Console.ForegroundColor;
            if (color != null)
            {
                Console.ForegroundColor = color.Value;
            }
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff > ") + message + dataString);
            if (color != null)
            {
                Console.ForegroundColor = savedColor;
            }
        }

        static T WrapExeptions<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                Log(ex.Message, color: ConsoleColor.Red);
            }
            return default(T);
        }
    }
}
