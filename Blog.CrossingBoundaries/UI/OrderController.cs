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

        public IEnumerable<OrderItemViewModel> FindOrders(string customerName, string productName)
        {
            var filterExpression = GetFilterExpression(customerName, productName);

            var orderModelItems = orderManager.FindOrderItems(filterExpression);

            return mapper.Map<List<OrderItemViewModel>>(orderModelItems);
        }

        private Expression<Func<OrderItemModel, bool>> GetFilterExpression(string customerName, string productName)
        {
            var parameterExpression = FilterHelper.GetParameterExpression<OrderItemViewModel>();

            var customerExpression = string.IsNullOrWhiteSpace(customerName) ? null : FilterHelper.CreateExpression<OrderItemViewModel>(nameof(OrderItemViewModel.CustomerName), customerName, parameterExpression);
            var productExpression = string.IsNullOrWhiteSpace(productName) ? null : FilterHelper.CreateExpression<OrderItemViewModel>(nameof(OrderItemViewModel.ProductName), productName, parameterExpression);

            Expression<Func<OrderItemViewModel, bool>> resultingExpression = null;

            if (customerExpression != null && productExpression != null)
            {
                var combination = Expression.AndAlso(customerExpression, productExpression);
                resultingExpression = Expression.Lambda<Func<OrderItemViewModel, bool>>(combination, parameterExpression);
            }
            else
            {
                resultingExpression = customerExpression ?? productExpression ?? Expression.Lambda<Func<OrderItemViewModel, bool>>(Expression.Constant(true), parameterExpression);
            }

            return mapper.MapExpression<Expression<Func<OrderItemModel, bool>>>(resultingExpression);
        }
    }
}
