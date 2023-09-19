using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Employee.DeleteEmployee
{
	public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest,DeleteEmployeeCommandResponse>
	{
        private readonly IEmployeeWriteRepository _employeeWriteRepository;
		public DeleteEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository)
		{
            _employeeWriteRepository = employeeWriteRepository;
		}

        public async Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            await _employeeWriteRepository.RemoveAsync(request.Id);
            await _employeeWriteRepository.SaveAsync();
            return new DeleteEmployeeCommandResponse();
        }
    }
}

