using CQRS.Commands.Product;
using CQRS.Dtos;
using CQRS.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        // TODO : BASE RESPONSE MODEL
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProductQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _mediator.Send(new GetProductByIdQuery { Id = id }));

        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProduct(int id, JsonPatchDocument<UpdateProductDto> updateProduct)
        {
            return Ok( await _mediator.Send(new PatchProductCommand { Id=id, UpdateProduct = updateProduct }));
        }
    }
}
