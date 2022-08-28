using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Brands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.Catalog.Brands
{
    public interface IBrandService
    {
        bool AddBrand(Brand brand);
        Task<IEnumerable<Brand>> GetAllBrandsAsync();
        Task<Brand> GetBrandAsync(int id);
        bool DeleteBrand(int id);
        bool UpdateBrand(Brand brand);
        bool ExistBrand(int id);
    }
}
