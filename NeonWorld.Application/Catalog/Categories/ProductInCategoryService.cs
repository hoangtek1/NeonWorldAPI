using Microsoft.EntityFrameworkCore;
using NeonWorld.EF;
using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.Catalog.Categories
{
    public class ProductInCategoryService : IProductInCategoryService
    {
        private readonly NeonWorldDbContext _context;
        public ProductInCategoryService(NeonWorldDbContext context)
        {
            _context = context;
        }
        public bool AddProductInCategory(ProductInCategory productInCategory)
        {
            _context.ProductInCategories.Add(productInCategory);

            return _context.SaveChanges() > 0;
        }

        public async Task<IEnumerable<ProductInCategory>> GetAllAsync()
        {
            return await _context.ProductInCategories.ToListAsync();
        }

        public async Task<IEnumerable<ProductInCategory>> GetProductInCategoryAsync(int categoryId, int productId)
        {
            var findProductInCategory = await _context.ProductInCategories
                .Where(x => (x.CategoryID == categoryId) 
                && (x.ProductID == productId)).ToListAsync();
            return findProductInCategory;
        }

        public async Task<bool> ExistCategoryAndProduct(int categoryId, int productId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryID == categoryId);
            var product = await _context.Products.FirstOrDefaultAsync(c => c.ProductID == productId);
            if (category == null && product == null)
            {
                return false;
            }
            return true;
        }
    }
}
