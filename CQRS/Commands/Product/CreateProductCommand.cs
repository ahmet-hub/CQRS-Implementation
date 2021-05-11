using CQRS.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Commands.Product
{
    public class CreateProductCommand:IRequest<ProductDto>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
