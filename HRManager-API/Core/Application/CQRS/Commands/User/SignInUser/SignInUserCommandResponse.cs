using System;
using Application.DTOs;

namespace Application.CQRS.Commands.User.SignInUser
{
	public class SignInUserCommandResponse
	{
        public bool isSucceced { get; set; }
        public string Message { get; set; }
        public Token Token { get; set; }
    }
}

