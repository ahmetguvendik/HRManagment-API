﻿using Application.CQRS.Commands.User.CreateUser;
using Application.CQRS.Commands.User.SignInUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prenstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(CreateUserCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(SignInUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

