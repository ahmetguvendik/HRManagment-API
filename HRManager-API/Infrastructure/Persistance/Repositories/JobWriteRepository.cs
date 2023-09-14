using System;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class JobWriteRepository : WriteRepository<Job>, IJobWriteRepository
    {
        public JobWriteRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}

