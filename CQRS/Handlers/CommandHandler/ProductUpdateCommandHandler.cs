using CQRS.Commands.Product;
using CQRS.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Handlers.CommandHandler
{
    public class ProductUpdateCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly DAL.AppContext _appContext;

        public ProductUpdateCommandHandler(DAL.AppContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _appContext.Product.Update(request.Product);
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
