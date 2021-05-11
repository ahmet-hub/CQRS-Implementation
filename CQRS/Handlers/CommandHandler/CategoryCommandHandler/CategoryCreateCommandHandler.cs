using AutoMapper;
using CQRS.Commands.Category;
using CQRS.Dtos;
using CQRS.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Handlers.CommandHandler.CategoryCommandHandler
{
    public class CategoryCreateCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly DAL.AppContext _appContext;
        private readonly IMapper _mapper;

        public CategoryCreateCommandHandler(DAL.AppContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _appContext.Categories.AddAsync(_mapper.Map<Category>(request));
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
