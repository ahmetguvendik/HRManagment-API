using Application.CQRS.Commands.Category.UpdateCategory;
using Application.CQRS.Commands.Job.CreateJob;
using Application.CQRS.Commands.Job.RemoveJob;
using Application.CQRS.Commands.Job.UpdateJob;
using Application.CQRS.Queries.Job.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prenstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : Controller
    {
        private readonly IMediator _mediator;
        public JobController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetJob([FromQuery] GetAllJobQueryRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateJob(CreateJobCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteJob([FromRoute] RemoveJobCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJob([FromBody] UpdateJobCommadRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
    }
}

