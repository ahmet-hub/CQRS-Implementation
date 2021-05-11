using AutoMapper;
using CQRS.Dtos;
using CQRS.Queries.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Handlers.QueryHandler
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
    {
        private readonly DAL.AppContext _appContext;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(DAL.AppContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _appContext.Categories.ToListAsync();

            return _mapper.Map<List<CategoryDto>>(result);

        }
    }
}
