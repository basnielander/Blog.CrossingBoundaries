using Blog.CrossingBoundaries.Domain.Models;
using System.Linq;

namespace Blog.CrossingBoundaries.Domain.Interfaces
{
    public interface IOrderManager
    {
        IQueryable<OrderItemModel> SelectOrderItems();
    }
}
