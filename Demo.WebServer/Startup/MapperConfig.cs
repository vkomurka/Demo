using AutoMapper;
using Demo.Contracts.Dtos;
using Demo.WebServer.Model.Entities;
using Microsoft.AspNetCore.Identity;

namespace Demo.WebServer.Startup;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Uom, UomDto>().ReverseMap();
        CreateMap<UserDto, IdentityUser>().ReverseMap();
        CreateMap<Warehouse, WarehouseDto>().ReverseMap();
    }
}
