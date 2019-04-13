﻿using AutoMapper;
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

        public IQueryable<OrderModel> SelectOrders()
        {
            var orderEntities = dbContext.Orders                            
                                .Include("OrderItems")
                                .Include("Customer");
                            
            var orderItems = mapper.Map<List<OrderModel>>(orderEntities);
            return orderItems.AsQueryable();
        }
    }
}
