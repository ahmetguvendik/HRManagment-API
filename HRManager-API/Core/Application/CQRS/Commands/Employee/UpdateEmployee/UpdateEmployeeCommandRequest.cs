using System;
using MediatR;

namespace Application.CQRS.Commands.Employee.UpdateEmployee
{
	public class UpdateEmployeeCommandRequest : IRequest<UpdateEmployeeCommandResponse>
	{
		public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Desription { get; set; }
        public string UserId { get; set; }
        public string JobId { get; set; }
    }
}

