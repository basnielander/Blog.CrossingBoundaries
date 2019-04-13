using Blog.CrossingBoundaries.UI.ViewModels;
using System.Collections.Generic;

namespace Blog.CrossingBoundaries.UI.Interfaces
{
    public interface IOrderController
    {
        IEnumerable<OrderItemViewModel> FindOrderItems(string customerName, string productName);
    }
}
