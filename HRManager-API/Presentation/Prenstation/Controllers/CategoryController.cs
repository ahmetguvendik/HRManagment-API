using Application.CQRS.Commands.Category.CreateCategory;
using Application.CQRS.Commands.Category.RemoveCategory;
using Application.CQRS.Queries.Category.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prenstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("[action]")]
        public IActionResult GetCategory([FromQuery] GetAllCategoryQueryRequest model)
        {
            var response = _mediator.Send(model);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response); 
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCategoryCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
    }
}

