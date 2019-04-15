using Blog.CrossingBoundaries.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.CrossingBoundaries.Domain.Interfaces
{
    public interface IOrderManager
    {
        IQueryable<OrderItemModel> FindOrderItems(string customerName, string productName);
    }
}
