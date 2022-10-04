using AutoMapper;
using EmployeeManagementAppAPI.DataModels;
using EmployeeManagementAppAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAppAPI.Controllers
{
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var employees = await employeeRepository.GetEmployeesAsync();

            return Ok(mapper.Map<List<Employee>>(employees));
        }
    }
}
