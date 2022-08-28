using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Entities
{
    public class OrderDetail
    {
        public Guid OrderID { set; get; }
        public int ProductID { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
