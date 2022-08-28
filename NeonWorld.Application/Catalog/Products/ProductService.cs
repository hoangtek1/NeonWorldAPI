using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NeonWorld.BackendApi.Helpers;
using NeonWorld.BackendApi.ResourceParameters;
using NeonWorld.EF;
using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly NeonWorldDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(NeonWorldDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddProduct(ProductCreateVm productCreateVm)
        {
            var productEntity = _mapper.Map<Product>(productCreateVm);
            productEntity.DateCreated = DateTime.Now;
            _context.Products.Add(productEntity);

            if(await _context.SaveChangesAsync() > 0)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Name.Equals(productCreateVm.Name));

                foreach (var image in productCreateVm.ProductImages)
                {
                    image.ProductID = product.ProductID;
                    image.DateCreated = DateTime.Now;
                    _context.ProductImages.Add(image);
                }
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> BrandExist(int brandID)
        {
            return await _context.Brands.AnyAsync(b => b.BrandID == brandID);
        }

        public async Task<PagedList<ProductVm>> GetAllProductsAsync(ProductsResourceParameters resource)
        {
            var mainCategory = resource.mainCategory;
            var searchQuery = resource.searchQuery;
            var sort = resource.Sort;

            var collection = _context.Products as IQueryable<Product>;
            if (mainCategory > 0)
            {
                collection = from pic in _context.ProductInCategories
                             join p in _context.Products on pic.ProductID equals p.ProductID
                             where pic.CategoryID == mainCategory
                             select p;
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(sort))
            {
                sort = sort.Trim();
                var sortFormat = sort.Split(" ");
                var isDesc = sortFormat[1] == "desc" ? true : false;
                collection = collection.OrderBy(sortFormat[0], isDesc);
            }

            collection = PriceFilter(collection, resource.Min, resource.Max);

            var productResults = from c in collection
                                 join pi in _context.ProductImages on c.ProductID equals pi.ProductID
                                 join b in _context.Brands on c.BrandID equals b.BrandID
                                 select new ProductVm()
                                 {
                                     Id = c.ProductID,
                                     Product_name = c.Name,
                                     Img = pi.ImagePath,
                                     Price = c.Price,
                                     Discount = c.Discount,
                                     Description = c.Description,
                                     Create_at = c.DateCreated,
                                     Sold = c.Sold,
                                     Brand_name = b.Name
                                 };
            return PagedList<ProductVm>.Create(await productResults.ToListAsync(),
                resource.Page, resource.PageSize);
        }

        public IQueryable<Product> PriceFilter(IQueryable<Product> collection, 
            decimal minPrice, decimal maxPrice)
        {
            if (minPrice > 0 && maxPrice > 0)
            {
                return collection.Where(a => (a.Price >= minPrice) && (a.Price <= maxPrice));
            }
            else if (minPrice <= 0 && maxPrice > 0)
            {
                return collection.Where(a => a.Price <= maxPrice);
            }
            else if (minPrice > 0 && maxPrice <= 0)
            {
                return collection.Where(a => a.Price >= minPrice);
            }
            return collection;
        }
        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductID == id);
        }
    }
}
