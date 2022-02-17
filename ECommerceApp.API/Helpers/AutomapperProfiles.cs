using AutoMapper;
using ECommerceApp.API.Dtos;
using ECommerceApp.API.Models;

namespace ECommerceApp.API.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Product, ProductForListDto>();
            CreateMap<ProductForCreationDto, Product>().ReverseMap();
            CreateMap<CategoryForCreationDto, Category>().ReverseMap();
            CreateMap<Product, ProductToReturnDto>();
            CreateMap<Category, CategoryForListDto>();

        }

    }
}