using Application.CQRS.Commands.Employee.CreateEmployee;
using Application.CQRS.Commands.Employee.DeleteEmployee;
using Application.CQRS.Commands.Employee.UpdateEmployee;
using Application.CQRS.Queries.Employee.GetAllEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prenstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployee([FromQuery] GetAllEmployeeQueryRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
            
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] DeleteEmployeeCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

    }
}

