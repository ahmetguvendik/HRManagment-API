using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        public UpdateCategoryCommandHandler(ICategoryReadRepository categoryReadRepository,ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }
        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetById(request.Id);
            category.CategoryName = request.Name;
            await _categoryWriteRepository.SaveAsync();
            return new UpdateCategoryCommandResponse();
        }
    }
}

