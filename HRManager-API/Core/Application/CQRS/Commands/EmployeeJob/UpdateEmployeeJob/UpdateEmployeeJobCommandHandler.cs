using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.EmployeeJob.UpdateEmployeeJob
{
	public class UpdateEmployeeJobCommandHandler : IRequestHandler<UpdateEmployeeJobCommandRequest,UpdateEmployeeJobCommandResponse>
	{
        private readonly IEmployeeJobReadRepository _employeeJobReadRepository;
        private readonly IEmployeeJobWriteRepository _employeeJobWriteRepository;
		public UpdateEmployeeJobCommandHandler(IEmployeeJobReadRepository employeeJobReadRepository,IEmployeeJobWriteRepository employeeJobWriteRepository)
		{
            _employeeJobReadRepository = employeeJobReadRepository;
            _employeeJobWriteRepository = employeeJobWriteRepository;
		}

        public async Task<UpdateEmployeeJobCommandResponse> Handle(UpdateEmployeeJobCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeJob = await _employeeJobReadRepository.GetById(request.Id);
            employeeJob.IsOk = request.IsOk;
            employeeJob.IsRed = request.IsRed;
            await _employeeJobWriteRepository.SaveAsync();
            return new UpdateEmployeeJobCommandResponse();
        }
    }
}

