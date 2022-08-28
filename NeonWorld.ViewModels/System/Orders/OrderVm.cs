using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.ViewModels.System.Orders
{
    public class OrderVm
    {
        public Guid OrderID { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserID { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public string ShipNote { set; get; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
