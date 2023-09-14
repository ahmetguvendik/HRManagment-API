using System;
namespace Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandResponse
	{
		public bool isSucceced { get; set; }
		public string Message { get; set; }	
	}
}

