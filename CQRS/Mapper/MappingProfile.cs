using AutoMapper;
using CQRS.Dtos;
using CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

         /*   CreateMap<Category, CategoryDto>();
            CreateMap<ProductDto, Category>();*/
        }
    }
}
