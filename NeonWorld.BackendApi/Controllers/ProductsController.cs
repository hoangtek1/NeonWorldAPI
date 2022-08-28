using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NeonWorld.Application.Catalog.Products;
using NeonWorld.BackendApi.Helpers;
using NeonWorld.BackendApi.ResourceParameters;
using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Products;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace NeonWorld.BackendApi.Controllers
{
    [Route("api/Products")]
    [ApiController]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductAsync(id);
            if (product == null)
            {
                return BadRequest($"Can't find Product with id: {id}");
            }
            var productVm = _mapper.Map<ProductVm>(product);
            return Ok(productVm);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetProducts(
            [FromQuery] ProductsResourceParameters productsResourceParameters)
        {
            if (productsResourceParameters == null)
            {
                return BadRequest();
            }
            var product = await _productService.GetAllProductsAsync(productsResourceParameters);
            return Ok(new
            {
                products = new
                {
                    last_page = product.TotalPages,
                    total = product.CurrentPage,
                    data = product
                }
            });
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm]ProductCreateVm productCreateVm)
        {
            if (await _productService.BrandExist(productCreateVm.BrandID))
            {
                await _productService.AddProduct(productCreateVm);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("CreateProductCollection")]
        public IActionResult CreateProductCollection(
            [FromBody]IEnumerable<ProductCreateVm> productCreateCollection)
        {
            foreach (var product in productCreateCollection)
            {
                _productService.AddProduct(product);
            }
            return Ok("Okee");
        }
    }
}
