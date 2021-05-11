using CQRS.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Commands.Category
{
    public class CreateCategoryCommand:IRequest<CategoryDto>
    {
        public string Name { get; set; }
    }
}
