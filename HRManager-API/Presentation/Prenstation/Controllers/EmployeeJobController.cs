using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Queries.EmployeeJob.GetAllEmployeeJob;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prenstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeJobController : Controller
    {
        private readonly IMediator _mediator;
        public EmployeeJobController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployeeJob([FromQuery] GetAllEmployeeJobQueryRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
    }
}

