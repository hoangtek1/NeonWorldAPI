using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        bool AddCategory(Category categoryVm);
        bool DeleteCategory(int id);
        bool UpdateCategory(Category category);
        bool ExistCategory(int id);
    }
}
