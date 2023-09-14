using AutoMapper;
using SimpleProductCRUD.API.SemCopilot.DTOs;
using SimpleProductCRUD.API.SemCopilot.Entities;

namespace SimpleProductCRUD.API.SemCopilot.Mappings;

public class EntityToDTOMappingProfile : Profile
{
    public EntityToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}