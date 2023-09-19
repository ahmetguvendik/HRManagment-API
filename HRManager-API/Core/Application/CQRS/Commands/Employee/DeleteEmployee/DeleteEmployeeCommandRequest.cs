using System;
using MediatR;

namespace Application.CQRS.Commands.Employee.DeleteEmployee
{
	public class DeleteEmployeeCommandRequest : IRequest<DeleteEmployeeCommandResponse>
	{
		public string Id { get; set; }	
	}
}

