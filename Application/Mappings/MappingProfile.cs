using Application.Dtos.Books;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Book mappings
            CreateMap<Book, BookDto>().ReverseMap();

            // Category mappings (including Books)
            CreateMap<Category, CategoryDto>()
                .ReverseMap();
        }
    }
}

