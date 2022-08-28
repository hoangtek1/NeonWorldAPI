using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeonWorld.Application.Catalog.Brands;
using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Brands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeonWorld.BackendApi.Controllers
{
    [Route("api/Brands")]
    [ApiController]
    [Authorize]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _brandService.GetBrandAsync(id);
            if(brand == null)
            {
                return NotFound($"Can't find Brand with id: {id}");
            }
            return Ok(brand);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            return Ok(brands);
        }

        [HttpPost]
        public IActionResult CreateBrand([FromBody] BrandVm brandVm)
        {
            if(brandVm == null)
            {
                return BadRequest();
            }
            var brandEntity = _mapper.Map<Brand>(brandVm);
            var addStatus = _brandService.AddBrand(brandEntity);
            if (addStatus)
            {
                return Ok("Create Brand successfully!");
            }
            return BadRequest("Create Brand fail!");
        }

        [HttpPost("BrandCollections")]
        public IActionResult CreateBrandCollections(
            [FromBody] IEnumerable<BrandVm> brandVmCollections)
        {
            var brandEntityCollections = _mapper.Map<IEnumerable<Brand>>(brandVmCollections);
            foreach (var brand in brandEntityCollections)
            {
                _brandService.AddBrand(brand);
            }
            return Ok("Create Brand collections successfully!");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBrand(int id, [FromBody]Brand brandRequest)
        {
            if (_brandService.ExistBrand(id))
            {
                brandRequest.BrandID = id;
                var updateStatus = _brandService.UpdateBrand(brandRequest);
                if (updateStatus)
                {
                    return Ok("Update Brand successfully!");
                }
                return BadRequest("Update Brand fail");
            }
            return NotFound($"Can't find Brand with id: {id}");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBrand(int id)
        {
            if (_brandService.ExistBrand(id))
            {
                var deteleStatus = _brandService.DeleteBrand(id);
                if (deteleStatus)
                {
                    return Ok("Delete Brand successfully!");
                }
                return BadRequest("Delete Brand fail");
            }
            return NotFound($"Can't find Brand with id: {id}");
        }
    }
}
