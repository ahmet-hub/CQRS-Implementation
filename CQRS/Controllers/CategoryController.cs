using CQRS.Commands.Category;
using CQRS.Queries.Category;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using CQRS.Dtos;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllCategoryQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetCategoryQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommand createCategoryCommand)
        {
            return Ok(await _mediator.Send(createCategoryCommand));

        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryCommand updateCategoryCommand)
        {
            return Ok(await _mediator.Send(updateCategoryCommand));
        }
        [HttpPatch]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<UpdateCategoryDto> updateCategory )
        {
            return Ok(await _mediator.Send(new PatchCategoryCommand { Id = id, UpdateCategory = updateCategory }));
        }


    }
}
