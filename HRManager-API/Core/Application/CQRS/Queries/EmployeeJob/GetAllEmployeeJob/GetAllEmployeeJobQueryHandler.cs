using System;
using Application.Services;
using MediatR;

namespace Application.CQRS.Queries.EmployeeJob.GetAllEmployeeJob
{
	public class GetAllEmployeeJobQueryHandler : IRequestHandler<GetAllEmployeeJobQueryRequest,GetAllEmployeeJobQueryResponse>
	{
        private readonly IEmployeeJobService _employeeJobService;
		public GetAllEmployeeJobQueryHandler(IEmployeeJobService employeeJobService)
		{
            _employeeJobService = employeeJobService;
		}

        public async Task<GetAllEmployeeJobQueryResponse> Handle(GetAllEmployeeJobQueryRequest request, CancellationToken cancellationToken)
        {
           var employeeJobs =  _employeeJobService.GetEmployeeJob();
            return new GetAllEmployeeJobQueryResponse()
            {
                EmployeeJobs = employeeJobs
            };
        }
    }
}

