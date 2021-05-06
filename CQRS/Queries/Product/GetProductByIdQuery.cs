using AutoMapper;
using CQRS.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Queries.Product
{
    public class GetProductByIdQuery:IRequest<ProductDto>
    {
        public int Id { get; set; }
    
    }
}
