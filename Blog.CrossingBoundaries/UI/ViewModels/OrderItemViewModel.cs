using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.CrossingBoundaries.UI.ViewModels
{
    public class OrderItemViewModel
    {
        public string CustomerName { get; set; }

        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }
    }
}
