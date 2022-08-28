using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Entities
{
    public class ProductImage
    {
        public int ProductImageID { get; set; }
        public int ProductID { get; set; }
        public string ImagePath { get; set; }
        public Status IsDefault { get; set; }
        public DateTime DateCreated { get; set; }
        public int SortOrder { get; set; }
        public long FileSize { get; set; }
        public Product Product { get; set; }
    }
}
