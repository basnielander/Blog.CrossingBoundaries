namespace Blog.CrossingBoundaries.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public Order Order { get; set; }
    }
}
