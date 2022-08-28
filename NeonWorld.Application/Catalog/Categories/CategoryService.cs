using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NeonWorld.EF;
using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly NeonWorldDbContext _context;

        public CategoryService(NeonWorldDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryID == id);
        }
        public bool AddCategory(Category category)
        {
            _context.Categories.Add(category);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteCategory(int id)
        {
            var category = _context.Categories
                .FirstOrDefault(c => c.CategoryID == id);
            _context.Categories.Remove(category);
            return _context.SaveChanges() > 0;
        }

        public bool ExistCategory(int id)
        {
            return _context.Categories.Any(c => c.CategoryID == id);
        }
    }
}
