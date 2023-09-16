using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Job.GetAll
{
	public class GetAllJobQueryHandler : IRequestHandler<GetAllJobQueryRequest,GetAllJobQueryResponse>
	{
        private readonly IJobReadRepository _jobReadRepository;
		public GetAllJobQueryHandler(IJobReadRepository jobReadRepository)
		{
            _jobReadRepository = jobReadRepository;
		}

        public async Task<GetAllJobQueryResponse> Handle(GetAllJobQueryRequest request, CancellationToken cancellationToken)
        {
            var jobs =  _jobReadRepository.GetAll();
            return new GetAllJobQueryResponse()
            {
                Jobs = jobs
            };
      
        }
    }
}

