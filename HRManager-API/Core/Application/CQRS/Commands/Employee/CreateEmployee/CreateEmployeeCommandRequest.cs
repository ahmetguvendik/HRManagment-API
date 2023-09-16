using System;
using MediatR;

namespace Application.CQRS.Commands.Employee.CreateEmployee
{
	public class CreateEmployeeCommandRequest : IRequest<CreateEmployeeCommandResponse>
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Title { get; set; }
		public string Desription { get; set; }
		public string UserId { get; set; }
		public string JobId { get; set; }	
	}
}

