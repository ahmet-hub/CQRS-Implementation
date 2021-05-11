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
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly DAL.AppContext _appContext;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(DAL.AppContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _appContext.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            return _mapper.Map<CategoryDto>(result);
        }
    }
}
