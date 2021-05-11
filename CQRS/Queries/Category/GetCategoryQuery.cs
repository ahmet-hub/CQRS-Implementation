using CQRS.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Queries.Category
{
    public class GetCategoryQuery:IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
