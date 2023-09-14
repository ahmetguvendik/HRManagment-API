using System;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
	{
        private readonly UserManager<AppUser> _userManager;
		public CreateUserCommandHandler(UserManager<AppUser> userManager)
		{
            _userManager = userManager;
		}

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new AppUser();
            user.Id = Guid.NewGuid().ToString();
            user.Email = request.Email;
            user.UserName = request.UserName;
            user.PhoneNumber = request.PhoneNumber;
            if (request.Password == request.PasswordConfirm)
            {

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    return new CreateUserCommandResponse()
                    {
                        isSucceced = result.Succeeded,
                        Message = "OK"
                    };
                }
            }

            return new CreateUserCommandResponse()
            {
                isSucceced = false,
                Message = "SIFRELER UYUSMUYOR"
            };
        }
    }
}

