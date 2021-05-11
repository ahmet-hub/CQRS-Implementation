using AutoMapper;
using CQRS.Commands.Category;
using CQRS.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Handlers.CommandHandler.CategoryCommandHandler
{
    public class CategoryPatchCommandHandler : IRequestHandler<PatchCategoryCommand, CategoryDto>
    {
        private readonly DAL.AppContext _appContext;
        private readonly IMapper _mapper;

        public CategoryPatchCommandHandler(DAL.AppContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(PatchCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _appContext.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (category == null) return null;

                var updateCategory = _mapper.Map<UpdateCategoryDto>(category);

                request.UpdateCategory.ApplyTo(updateCategory);

                var entity = _mapper.Map(updateCategory, category);
                _appContext.Categories.Attach(entity);

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
