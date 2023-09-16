using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Employee.CreateEmployee
{
	public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest,CreateEmployeeCommandResponse>
	{
        private readonly IEmployeeWriteRepository _employeeWriteRepository;
        private readonly IEmployeeJobWriteRepository _employeeJobWriteRepository;
		public CreateEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository,IEmployeeJobWriteRepository employeeJobWriteRepository)
		{
            _employeeWriteRepository = employeeWriteRepository;
            _employeeJobWriteRepository = employeeJobWriteRepository;
		}

        public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            var employee = new Domain.Entities.Employee();
            employee.Id = Guid.NewGuid().ToString();
            employee.Name = request.Name;
            employee.Surname = request.Surname;
            employee.Title = request.Title;
            employee.Description = request.Desription;
            var emplooyeeJob = new Domain.Entities.EmployeeJob();
            emplooyeeJob.Id = Guid.NewGuid().ToString();
            emplooyeeJob.EmployeeId = employee.Id;
            emplooyeeJob.JobId = request.JobId;
            employee.UserId = request.UserId;
            await _employeeJobWriteRepository.AddAsync(emplooyeeJob);
            await _employeeWriteRepository.AddAsync(employee);
            await _employeeWriteRepository.SaveAsync();
            return new CreateEmployeeCommandResponse();
        }
    }
}

