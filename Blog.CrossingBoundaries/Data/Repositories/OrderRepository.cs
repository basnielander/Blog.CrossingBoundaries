using AutoMapper;
using Blog.CrossingBoundaries.Domain.Interfaces;
using Blog.CrossingBoundaries.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public IQueryable<OrderItemModel> SelectOrderItems()
        {
            var orderEntities = dbContext.OrderItems
                            .Include("Order.Customer");
                            
            var orderItems = mapper.Map<List<OrderItemModel>>(orderEntities);
            return orderItems.AsQueryable();
        }
    }
}
