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
    public class ProductCreateCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly DAL.AppContext _appContext;

        public ProductCreateCommandHandler(DAL.AppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appContext.Product.AddAsync(request.Product, cancellationToken);
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
