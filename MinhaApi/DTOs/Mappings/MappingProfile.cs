using AutoMapper;
using MinhaApi.Data.Map;
using MinhaApi.Models;
using ProductsAPI.Models;

namespace ProductsAPI.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, ProductDTO>().ReverseMap();
            CreateMap<CategoryModel, CategoryDTO>().ReverseMap();
            CreateMap<AboutProductModel, AboutProductDTO>().ReverseMap();
        }
    }
}
