using Blog.CrossingBoundaries.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Blog.CrossingBoundaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var manager = DI.GetService<IOrderManager>();

            while (true)
            {
                Console.WriteLine("Customer query: ");
                string customerQuery = Console.ReadLine();
                Console.WriteLine("Product query: ");
                string productQuery = Console.ReadLine();

                var results = manager.SelectOrders();

                var filteredResults = results.Where(order => (string.IsNullOrWhiteSpace(customerQuery) || order.Customer.Name.Contains(customerQuery)) &&
                                                             (string.IsNullOrWhiteSpace(productQuery) || order.OrderItems.Any(orderItem => orderItem.ProductName.Contains(productQuery))));

                var resultsStr = JsonConvert.SerializeObject(filteredResults, Formatting.Indented);
                Console.WriteLine(resultsStr);
                Console.WriteLine();
            }
        }
    }
}
