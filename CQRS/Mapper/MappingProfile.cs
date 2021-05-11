using AutoMapper;
using CQRS.Commands.Category;
using CQRS.Commands.Product;
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
            #region Product

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, UpdateProductDto>();
          
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            #endregion

            #region Category

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();
            
            
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();

            #endregion

        }
    }
}
