using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Entities
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public int Authority { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
