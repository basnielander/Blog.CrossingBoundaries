using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.CrossingBoundaries.Data.Entities;
using Blog.CrossingBoundaries.Domain.Interfaces;
using Blog.CrossingBoundaries.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.CrossingBoundaries.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext dbContext;
        private readonly IMapper mapper;

        public OrderRepository(DatabaseContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IQueryable<OrderModel> FindOrders(string customerName, string productName)
        {
            var orderEntities = dbContext.Orders                            
                            .Include("OrderItems")
                            .Include("Customer")
                            .Where(order => (string.IsNullOrWhiteSpace(customerName) || order.Customer.Name.Contains(customerName)) &&
                                            (string.IsNullOrWhiteSpace(productName) || order.OrderItems.Any(orderItem => orderItem.ProductName.Contains(productName))));
                            
            var orderItems = mapper.Map<List<OrderModel>>(orderEntities);
            return orderItems.AsQueryable();
        }
    }
}
