using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeonWorld.Application.Catalog.Categories;
using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Products;
using System.Threading.Tasks;

namespace NeonWorld.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductInCategoryController : ControllerBase
    {
        private readonly IProductInCategoryService _productInCategoryService;
        private readonly IMapper _mapper;
        public ProductInCategoryController(IProductInCategoryService productInCategoryService,
            IMapper mapper)
        {
            _productInCategoryService = productInCategoryService;
            _mapper = mapper;   
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProductInCategoryVm productInCategoryVm)
        {
            if (productInCategoryVm == null)
            {
                return NotFound();
            }
            var isExistCategoryAndProduct = _productInCategoryService
                .ExistCategoryAndProduct(productInCategoryVm.CategoryID, productInCategoryVm.ProductID);
            if (await isExistCategoryAndProduct)
            {
                var productInCategoryEntity = _mapper.Map<ProductInCategory>(productInCategoryVm);
                var addProductInCategory = _productInCategoryService.AddProductInCategory(productInCategoryEntity);
                if (addProductInCategory)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return NotFound();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProductInCategory()
        {
            var listProductInCategory = await _productInCategoryService.GetAllAsync();
            return Ok(listProductInCategory);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductInCategory([FromQuery]ProductInCategoryVm productInCategoryVm)
        {
            if (productInCategoryVm == null)
            {
                return NotFound();
            }
            var productInCategory = await _productInCategoryService
                .GetProductInCategoryAsync(productInCategoryVm.CategoryID, productInCategoryVm.ProductID);
            if(productInCategory == null)
            {
                return NotFound();
            }
            return Ok(productInCategory);
        }
    }
}
