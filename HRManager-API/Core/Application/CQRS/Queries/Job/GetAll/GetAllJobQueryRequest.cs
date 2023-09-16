using System;
using MediatR;

namespace Application.CQRS.Queries.Job.GetAll
{
	public class GetAllJobQueryRequest : IRequest<GetAllJobQueryResponse>
	{
		public GetAllJobQueryRequest()
		{
		}
	}
}

