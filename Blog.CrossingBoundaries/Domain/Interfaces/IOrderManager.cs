using Blog.CrossingBoundaries.Domain.Models;
using System.Linq;

namespace Blog.CrossingBoundaries.Domain.Interfaces
{
    public interface IOrderManager
    {
        IQueryable<OrderItemModel> FindOrderItems(string customerName, string productName);
    }
}
