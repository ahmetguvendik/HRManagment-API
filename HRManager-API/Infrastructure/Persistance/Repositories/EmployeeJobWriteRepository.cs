﻿using System;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class EmployeeJobWriteRepository : WriteRepository<EmployeeJob>, IEmployeeJobWriteRepository
    {
        public EmployeeJobWriteRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}

