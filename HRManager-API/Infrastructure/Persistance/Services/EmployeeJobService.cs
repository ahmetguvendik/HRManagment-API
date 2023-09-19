﻿using System;
using Application.Repositories;
using Application.Services;
using Application.ViewModels;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace Persistance.Services
{
	public class EmployeeJobService : IEmployeeJobService
    {
        private readonly ProjectDbContext _context;
        private readonly IEmployeeJobReadRepository _employeeJobReadRepository;
        public EmployeeJobService(ProjectDbContext context,IEmployeeJobReadRepository employeeJobReadRepository)
		{
            _context = context;
            _employeeJobReadRepository = employeeJobReadRepository;
		}

        public IQueryable<Employee_Job_ViewModel> GetEmployeeJob()
        {
            var model = from j in _context.Jobs
                        join ej in _context.EmployeeJob
            on j.Id equals ej.JobId
                        join e in _context.Employees
             on ej.EmployeeId equals e.Id
                        join u in _context.Users
                       on e.UserId equals u.Id
                        select new Employee_Job_ViewModel
                        {
                            Id = ej.Id,
                            EmployeeName = e.Name,
                            JobName = j.JobName,
                            EmployeeSurname = e.Surname,
                            IsOk = ej.IsOk,
                            IsRed = ej.IsRed,
                            Username = u.UserName
                        };

            return model;
        }

        public IQueryable<Employee_Job_ViewModel> GetEmployeeJobById(string id)
        {
            var model = (from j in _context.Jobs
                         join ej in _context.EmployeeJob
             on j.Id equals ej.JobId
                         join e in _context.Employees
              on ej.EmployeeId equals e.Id
                         join u in _context.Users
             on e.UserId equals id
                         select new Employee_Job_ViewModel
                         {
                             Id = e.Id,
                             EmployeeName = e.Name,
                             JobName = j.JobName,
                             EmployeeSurname = e.Surname,
                             IsOk = ej.IsOk,
                             IsRed = ej.IsRed,
                         }).Distinct();

            return model;
        }
    }
}

