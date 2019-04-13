using System.Collections.Generic;

namespace Blog.CrossingBoundaries.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
