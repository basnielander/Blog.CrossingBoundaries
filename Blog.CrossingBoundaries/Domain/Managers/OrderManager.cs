using Blog.CrossingBoundaries.Domain.Interfaces;
using Blog.CrossingBoundaries.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.CrossingBoundaries.Domain.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository repository;

        public OrderManager(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public IQueryable<OrderModel> FindOrders(string customerName, string productName)
        {
            return repository.FindOrders(customerName, productName);
        }
    }
}
