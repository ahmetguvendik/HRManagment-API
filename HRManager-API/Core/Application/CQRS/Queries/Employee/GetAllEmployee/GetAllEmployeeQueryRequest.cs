using System;
using MediatR;

namespace Application.CQRS.Queries.Employee.GetAllEmployee
{
	public class GetAllEmployeeQueryRequest : IRequest<GetAllEmployeeQueryResponse>
	{
		public GetAllEmployeeQueryRequest()
		{
		}
	}
}

