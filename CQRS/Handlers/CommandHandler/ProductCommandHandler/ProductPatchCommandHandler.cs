using AutoMapper;
using CQRS.Commands.Product;
using CQRS.Dtos;
using CQRS.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Handlers.CommandHandler
{
    public class ProductPatchCommandHandler : IRequestHandler<PatchProductCommand, ProductDto>
    {
        private readonly DAL.AppContext _appContext;
        private readonly IMapper _mapper;

        public ProductPatchCommandHandler(DAL.AppContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(PatchProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product =
               await _appContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (product == null)
                    return null;

                var update = _mapper.Map<UpdateProductDto>(product);
                request.UpdateProduct.ApplyTo(update);
                var entity = _mapper.Map(update, product);

                _appContext.Products.Attach(entity);
                await _appContext.SaveChangesAsync();

                return null;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
