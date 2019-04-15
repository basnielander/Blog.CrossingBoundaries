using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Blog.CrossingBoundaries.Domain.Interfaces;
using Blog.CrossingBoundaries.Domain.Models;
using Blog.CrossingBoundaries.UI.Interfaces;
using Blog.CrossingBoundaries.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.CrossingBoundaries.UI
{
    public class OrderController : IOrderController
    {
        private readonly IOrderManager orderManager;
        private readonly IMapper mapper;

        public OrderController(IOrderManager orderManager, IMapper mapper)
        {
            this.orderManager = orderManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// FindOrderItems() method in the UI layer, calling the OrderManager in the Domain layer
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public IEnumerable<OrderItemViewModel> FindOrders(string customerName, string productName)
        {
            var orderModelItems = orderManager.FindOrderItems(customerName, productName);

            return mapper.Map<List<OrderItemViewModel>>(orderModelItems);
        }        
    }
}
