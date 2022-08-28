using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeonWorld.ViewModels.Catalog.Categories
{
    public class CategoryVm
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(300)]
        public string Icon { get; set; }
    }
}
