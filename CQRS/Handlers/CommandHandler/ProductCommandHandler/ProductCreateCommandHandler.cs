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
    public class ProductCreateCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly DAL.AppContext _appContext;
        private readonly IMapper _mapper;

        public ProductCreateCommandHandler(DAL.AppContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appContext.Products.AddAsync(_mapper.Map<Product>(request), cancellationToken);
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
