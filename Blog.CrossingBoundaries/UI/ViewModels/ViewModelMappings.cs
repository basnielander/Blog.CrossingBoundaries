using AutoMapper;
using Blog.CrossingBoundaries.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.CrossingBoundaries.UI.ViewModels
{
    public class ViewModelMappings : Profile
    {
        public ViewModelMappings()
        {
            CreateMap<OrderItemModel, OrderItemViewModel>()
                .ForMember(viewModel => viewModel.CustomerName, opt => opt.MapFrom(domainModel => domainModel.Order.Customer.Name))
                .ForMember(viewModel => viewModel.OrderId, opt => opt.MapFrom(domainModel => domainModel.Order.Id));
        }
    }
}
