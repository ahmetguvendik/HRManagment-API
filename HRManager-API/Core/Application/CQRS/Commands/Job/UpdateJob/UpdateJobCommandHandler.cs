using System;
using Application.Repositories;
using MediatR;

namespace Application.CQRS.Commands.Job.UpdateJob
{
	public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommadRequest,UpdateJobCommandResponse>
	{
        private readonly IJobReadRepository _jobReadRepository;
        private readonly IJobWriteRepository _jobWriteRepository;
		public UpdateJobCommandHandler(IJobReadRepository jobReadRepository,IJobWriteRepository jobWriteRepository)
		{
            _jobReadRepository = jobReadRepository;
            _jobWriteRepository = jobWriteRepository;
		}

        public async Task<UpdateJobCommandResponse> Handle(UpdateJobCommadRequest request, CancellationToken cancellationToken)
        {
            var job = await _jobReadRepository.GetById(request.Id);
            job.JobName = request.JobName;
            job.Level = request.Level;
            job.Type = request.Type;
            job.Description = request.Description;
            job.CategoryId = request.CategoryId;
            await _jobWriteRepository.SaveAsync();
            return new UpdateJobCommandResponse();
          
        }
    }
}

