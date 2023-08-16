using AutoMapper;
using Lorem.Core.Dtos.CategoryDtos;
using Lorem.Core.Dtos.ProductDtos;
using Lorem.Core.Dtos.ProductFeatureDtos;
using Lorem.Core.Entities;

namespace Lorem.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductWithCategory>().ReverseMap();
            CreateMap<Category, CategoryWithProductsDto>();
        }
    }
}
