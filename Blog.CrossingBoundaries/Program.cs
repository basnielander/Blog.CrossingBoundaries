using Blog.CrossingBoundaries.Domain.Interfaces;
using Newtonsoft.Json;
using System;

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

                var results = manager.FindOrders(customerQuery, productQuery);

                var resultsStr = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
                Console.WriteLine(resultsStr);
                Console.WriteLine();
            }
        }
    }
}
