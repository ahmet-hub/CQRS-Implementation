using AutoMapper;
using CQRS.Dtos;
using CQRS.Queries.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Handlers.QueryHandler
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly DAL.AppContext _appContext;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(DAL.AppContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result= await _appContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
             return _mapper.Map<ProductDto>(result);
        }
    }
}
