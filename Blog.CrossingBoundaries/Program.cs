using Blog.CrossingBoundaries.Domain.Interfaces;
using Blog.CrossingBoundaries.UI;
using Blog.CrossingBoundaries.UI.Interfaces;
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

            var controller = DI.GetService<IOrderController>();

            while (true)
            {
                Console.WriteLine("Customer query: ");
                string customerQuery = Console.ReadLine();
                Console.WriteLine("Product query: ");
                string productQuery = Console.ReadLine();

                var results = controller.FindOrderItems(customerQuery, productQuery);
                
                var resultsStr = JsonConvert.SerializeObject(results, Formatting.Indented);
                Console.WriteLine(resultsStr);
                Console.WriteLine();
            }
        }
    }
}
