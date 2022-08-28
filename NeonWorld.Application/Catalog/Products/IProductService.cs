using NeonWorld.BackendApi.Helpers;
using NeonWorld.BackendApi.ResourceParameters;
using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<bool> AddProduct(ProductCreateVm productCreateVm);
        Task<PagedList<ProductVm>> GetAllProductsAsync(ProductsResourceParameters productsResourceParameters);
        Task<bool> BrandExist(int brandID);
        Task<Product> GetProductAsync(int id);

    }
}
