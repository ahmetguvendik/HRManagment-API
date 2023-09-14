using System;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class EmployeeJobReadRepository : ReadRepository<EmployeeJob>, IEmployeeJobReadRepository
    {
        public EmployeeJobReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}

