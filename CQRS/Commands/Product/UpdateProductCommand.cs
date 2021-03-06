using CQRS.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Commands.Product
{
    public class UpdateProductCommand:IRequest<ProductDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

    }
}
