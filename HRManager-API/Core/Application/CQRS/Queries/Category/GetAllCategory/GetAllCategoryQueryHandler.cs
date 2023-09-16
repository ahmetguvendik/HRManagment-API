using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }
        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryReadRepository.GetAll();
            return new GetAllCategoryQueryResponse()
            {
                Categories = categories
            };
        }
    }
}

