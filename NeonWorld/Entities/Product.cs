using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public int Discount { get; set; }
        public int Stock { get; set; }
        public int Sold { get; set; }
        public DateTime DateCreated { set; get; }
        public DateTime DateUpdated { set; get; }
        public List<ProductImage> ProductImages { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Cart> Carts { get; set; }
        public int BrandID { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
