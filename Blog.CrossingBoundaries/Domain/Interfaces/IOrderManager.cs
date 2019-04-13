using Blog.CrossingBoundaries.Domain.Models;
using System.Linq;

namespace Blog.CrossingBoundaries.Domain.Interfaces
{
    public interface IOrderManager
    {
        IQueryable<OrderModel> FindOrders(string customerName, string productName);
    }
}
