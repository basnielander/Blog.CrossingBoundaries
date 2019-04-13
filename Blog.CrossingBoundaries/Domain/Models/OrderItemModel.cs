namespace Blog.CrossingBoundaries.Domain.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public OrderModel Order { get; set; }

    }
}
