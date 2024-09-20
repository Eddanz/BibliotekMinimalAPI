using AutoMapper;
using BibliotekMinimalAPI.Models;
using BibliotekMinimalAPI.Models.DTOs;

namespace BibliotekMinimalAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookCreateDTO>().ReverseMap();
            CreateMap<Book, BookUpdateDTO>().ReverseMap();
        }
    }
}
