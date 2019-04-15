using Blog.CrossingBoundaries.Domain.Interfaces;
using Blog.CrossingBoundaries.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        /// <summary>
        /// The FindOrderItems method applies a Where-statement on the IQueryable retrieved from the data layer. 
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public IQueryable<OrderItemModel> FindOrderItems(string customerName, string productName)
        {
            var orderItems = repository.SelectOrderItems()
                                        .Where(orderItem => (customerName == null || orderItem.Order.Customer.Name.Contains(customerName)) &&
                                                            (productName == null || orderItem.ProductName.Contains(productName)));

            return orderItems;
        }
    }
}
