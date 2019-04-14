using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
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

        /// <summary>
        /// Select orderitems from a database, including order and customer data,
        /// but now using UseAsDataSource(IMapper)
        /// </summary>
        /// <returns></returns>
        public IQueryable<OrderItemModel> SelectOrderItems()
        {
            var orderItems = dbContext.OrderItems
                            .Include("Order.Customer")
                            .UseAsDataSource(mapper).For<OrderItemModel>();
                            
            return orderItems.AsQueryable();
        }
    }
}
