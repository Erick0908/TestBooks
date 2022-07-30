using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBooks.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TestBooks.Domain.Entities.Books, TestBooks.Domain.DTOs.BooksDto>().ReverseMap();
                
        }


    }
}
