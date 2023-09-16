using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Queries.Employee.GetAllEmployee
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQueryRequest, GetAllEmployeeQueryResponse>
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        public GetAllEmployeeQueryHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }
        public async Task<GetAllEmployeeQueryResponse> Handle(GetAllEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            var employees = _employeeReadRepository.GetAll();
            return new GetAllEmployeeQueryResponse()
            {
                Employees = employees
            };
        }
    }
}

