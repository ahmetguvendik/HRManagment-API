using System;
using MediatR;

namespace Application.CQRS.Commands.EmployeeJob.UpdateEmployeeJob
{
	public class UpdateEmployeeJobCommandRequest : IRequest<UpdateEmployeeJobCommandResponse>
	{
        public string Id { get; set; }
        public string Username { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string JobName { get; set; }
        public bool IsOk { get; set; }
        public bool IsRed { get; set; }
    }
}

