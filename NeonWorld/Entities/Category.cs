using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
