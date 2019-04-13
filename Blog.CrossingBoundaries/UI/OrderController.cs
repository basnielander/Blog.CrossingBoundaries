using AutoMapper;
using Blog.CrossingBoundaries.Domain.Interfaces;
using Blog.CrossingBoundaries.UI.Interfaces;
using Blog.CrossingBoundaries.UI.ViewModels;
using System.Collections.Generic;

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
            var orderModelItems = orderManager.FindOrderItems(customerName, productName);

            return mapper.Map<List<OrderItemViewModel>>(orderModelItems);
        }
    }
}
