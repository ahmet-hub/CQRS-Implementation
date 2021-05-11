using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Dtos
{
    public record UpdateProductDto
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
