using AutoMapper;
using CQRS.DAL;
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
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductDto>>
    {
        private readonly DAL.AppContext _appContext;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(DAL.AppContext appContext,IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var result =  await _appContext.Product.ToListAsync();
            return _mapper.Map<List<ProductDto>>(result);
           
        }
    }
}
