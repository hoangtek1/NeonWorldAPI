using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Entities
{
    public class Order
    {
        public Guid OrderID { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserID { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public string ShipNote { set; get; }
        public OrderStatus Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public User User { set; get; }
    }
}
