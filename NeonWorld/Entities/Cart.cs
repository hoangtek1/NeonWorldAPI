using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Entities
{
    public class Cart
    {
        public int CartID { get; set; }
        public int ProductID { set; get; }
        public Guid UserID { get; set; }
        public int Quantity { set; get; }
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
