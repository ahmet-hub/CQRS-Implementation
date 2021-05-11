using AutoMapper;
using CQRS.Commands.Product;
using CQRS.Dtos;
using CQRS.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Handlers.CommandHandler
{
    public class ProductUpdateCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly DAL.AppContext _appContext;
        private readonly IMapper _mapper;
        public ProductUpdateCommandHandler(DAL.AppContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _appContext.Products.Update(_mapper.Map<Product>(request));
                await _appContext.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
