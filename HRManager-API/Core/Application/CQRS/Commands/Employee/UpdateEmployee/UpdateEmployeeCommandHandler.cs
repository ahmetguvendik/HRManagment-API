using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Employee.UpdateEmployee
{
	public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest,UpdateEmployeeCommandResponse>
	{
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IEmployeeWriteRepository _employeeWriteRepository;

        public UpdateEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository,IEmployeeReadRepository employeeReadRepository)
		{
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;

		}

        public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetById(request.Id);
            employee.Name = request.Name;
            employee.Surname = request.Surname;
            employee.Title = request.Title;
            employee.Description = request.Desription;
            employee.UserId = request.UserId;
            await _employeeWriteRepository.SaveAsync();
            return new UpdateEmployeeCommandResponse();
            
        }
    }
}

