using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.ViewModels.Catalog.Products
{
    public class ProductCreateVm
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public int Discount { get; set; }
        public int Stock { get; set; }
        public int Sold { get; set; }
        public int BrandID { get; set; }
        public List<ProductInCategoryVm> Categories { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
