using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.Catalog.Categories
{
    public interface IProductInCategoryService
    {
        Task<IEnumerable<ProductInCategory>> GetAllAsync();
        Task<IEnumerable<ProductInCategory>> GetProductInCategoryAsync(int categoryId, int productId);
        bool AddProductInCategory(ProductInCategory productInCategory);
        Task<bool> ExistCategoryAndProduct(int categoryId, int productId);
    }
}
