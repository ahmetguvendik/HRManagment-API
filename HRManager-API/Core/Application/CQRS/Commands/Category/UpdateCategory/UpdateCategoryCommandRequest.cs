using System;
using MediatR;

namespace Application.CQRS.Commands.Category.UpdateCategory
{
	public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
	{
		public string Id { get; set; }
		public string Name { get; set; }	
	}
}

