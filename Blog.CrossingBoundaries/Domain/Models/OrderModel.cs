using System.Collections.Generic;

namespace Blog.CrossingBoundaries.Domain.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public CustomerModel Customer { get; set; }

        public IEnumerable<OrderItemModel> OrderItems { get; set; }
    }
}
