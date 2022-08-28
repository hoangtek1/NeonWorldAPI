using NeonWorld.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.ViewModels.System.Carts
{
    public class CartVm
    {
        public ProductVm Product { get; set; }
        public int Amount { get; set; }
    }
}
