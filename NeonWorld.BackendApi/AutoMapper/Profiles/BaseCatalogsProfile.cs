using AutoMapper;
using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Brands;
using NeonWorld.ViewModels.Catalog.Categories;
using NeonWorld.ViewModels.Catalog.Products;
using System.Collections.Generic;

namespace NeonWorld.BackendApi.AutoMapper.Profiles
{
    public class BaseCatalogsProfile : Profile
    {
        public BaseCatalogsProfile()
        {
            CreateMap<Brand, BrandVm>().ReverseMap();
            CreateMap<Category, CategoryVm>().ReverseMap();
            CreateMap<Product, ProductVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductID))
                .ReverseMap();
            CreateMap<Product, ProductCreateVm>().ReverseMap();
            CreateMap<ProductInCategory, ProductInCategoryVm>().ReverseMap();
            //CreateMap<List<ProductInCategory>, List<ProductInCategoryVm>>().ReverseMap();
        }
    }
}
