using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.ViewModels.Catalog.Products
{
    public class ProductVm
    {
        public int Id { get; set; }
        public string Product_name { get; set; }
        public string Img { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public DateTime Create_at { get; set; }
        public int Sold { get; set; }
        public string Brand_name { get; set; }
    }
}
