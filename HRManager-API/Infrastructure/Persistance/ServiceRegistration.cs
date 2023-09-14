using System;
using Application.Repositories;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistance.Contexts;
using Persistance.Repositories;

namespace Persistance
{
    public static class ServiceRegistration
	{
        public static void AddPersistanceService(this IServiceCollection collection)
        {
            collection.AddDbContext<ProjectDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=HRManangmentAPIDb;"));
            collection.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ProjectDbContext>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
            collection.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            collection.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            collection.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            collection.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
            collection.AddScoped<IJobReadRepository, JobReadRepository>();
            collection.AddScoped<IJobWriteRepository, JobWriteRepository>();
            collection.AddScoped<IEmployeeJobWriteRepository, EmployeeJobWriteRepository>();
            collection.AddScoped<IEmployeeJobReadRepository, EmployeeJobReadRepository>();
            collection.AddScoped<ITokenHandler, Persistance.Services.TokenHandler>();

        }
    }
}

