using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeonWorld.ViewModels.Catalog.Brands
{
    public class BrandVm
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(300)]
        public string Logo { get; set; }
    }
}
