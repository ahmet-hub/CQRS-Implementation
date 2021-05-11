using CQRS.Dtos;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Commands.Category
{
    public class PatchCategoryCommand:IRequest<CategoryDto>
    {
        public int Id { get; set; }
        public JsonPatchDocument<UpdateCategoryDto> UpdateCategory { get; set; }
    }
}
