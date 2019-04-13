using Blog.CrossingBoundaries.Domain.Interfaces;
using Blog.CrossingBoundaries.Domain.Models;
using System.Linq;

namespace Blog.CrossingBoundaries.Domain.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository repository;

        public OrderManager(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public IQueryable<OrderModel> SelectOrders()
        {
            return repository.SelectOrders();
        }
    }
}
