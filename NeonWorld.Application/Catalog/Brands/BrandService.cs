using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NeonWorld.EF;
using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.Catalog.Brands
{
    public class BrandService : IBrandService
    {
        private readonly NeonWorldDbContext _context;

        public BrandService(NeonWorldDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetBrandAsync(int id)
        {
            return await _context.Brands.FirstOrDefaultAsync(b => b.BrandID == id);
        }

        public bool AddBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteBrand(int id)
        {
            var brand = _context.Brands
                .FirstOrDefault(b => b.BrandID == id);
            _context.Brands.Remove(brand);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateBrand(Brand brand)
        {
            _context.Brands.Update(brand);
            return _context.SaveChanges() > 0;
        }

        public bool ExistBrand(int id)
        {
            return _context.Brands.Any(b => b.BrandID == id);
        }
    }
}
