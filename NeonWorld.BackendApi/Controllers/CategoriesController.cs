using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeonWorld.Application.Catalog.Categories;
using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeonWorld.BackendApi.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);
            if(category == null)
            {
                return NotFound($"Can't find Brand with id: {id}");
            }
            return Ok(category);
        } 

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);

        }

        [HttpPost]
        public IActionResult CreateCategory([FromForm] CategoryVm categoryVm)
        {
            if (categoryVm == null)
            {
                return BadRequest();
            }
            var category = _mapper.Map<Category>(categoryVm);
            var addStatus = _categoryService.AddCategory(category);
            if (addStatus)
            {
                return Ok("Create Category successfully!");
            }
            return BadRequest("Create Category fail!");
        }

        [HttpPost("CategoryCollections")]
        public IActionResult CreateCategoryCollections(
            [FromBody] IEnumerable<CategoryVm> categoryVmCollections)
        {
            var categoryCollections = _mapper.Map<IEnumerable<Category>>(categoryVmCollections);
            foreach (var category in categoryCollections)
            {
                _categoryService.AddCategory(category);
            }
            return Ok("Create Category collection successfully!");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCategory(int id, [FromForm]Category categoryRequest)
        {
            if (_categoryService.ExistCategory(id))
            {
                categoryRequest.CategoryID = id;
                var updateStatus = _categoryService.UpdateCategory(categoryRequest);
                if (updateStatus)
                {
                    return Ok("Update Category successfully!");
                }
                return BadRequest("Update Category fail");
            }
            return NotFound($"Can't find Category with id: {id}");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCategory(int id)
        {
            if (_categoryService.ExistCategory(id))
            {
                var deleteStatus = _categoryService.DeleteCategory(id);
                if (deleteStatus)
                {
                    return Ok("Delete Category successfully!");
                }
                return BadRequest("Delete Category fail");
            }
            return NotFound($"Can't find Category with id: {id}");
        }
    }
}
