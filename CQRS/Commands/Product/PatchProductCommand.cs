using CQRS.Dtos;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Commands.Product
{
    public class PatchProductCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public JsonPatchDocument<UpdateProductDto> UpdateProduct { get; set; }
    }
}
