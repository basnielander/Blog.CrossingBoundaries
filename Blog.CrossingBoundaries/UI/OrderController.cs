using AutoMapper;
using Blog.CrossingBoundaries.Domain.Interfaces;
using Blog.CrossingBoundaries.UI.Interfaces;
using Blog.CrossingBoundaries.UI.ViewModels;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<OrderItemViewModel> FindOrderItems(string customerName, string productName)
        {
            var orderModelItems = orderManager.SelectOrderItems();
            var orderViewModelItems = mapper.Map<List<OrderItemViewModel>>(orderModelItems);

            return orderViewModelItems.Where(orderItem => (string.IsNullOrWhiteSpace(customerName) || orderItem.CustomerName.Contains(customerName)) &&
                                                          (string.IsNullOrWhiteSpace(productName) || orderItem.ProductName.Contains(productName)));
        }
    }
}
