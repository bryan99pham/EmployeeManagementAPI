using AutoMapper;
using EmployeeManagementAppAPI.DomainModels;
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
            //fetching all employees
            var employees = await employeeRepository.GetEmployeesAsync();

            return Ok(mapper.Map<List<Employee>>(employees));
        }

        [HttpGet]
        [Route("[controller]/{employeeId:guid}")]
        public async Task<IActionResult> GetEmployeeAsync([FromRoute] Guid employeeId)
        {
            //fetch employee information
            var employee = await employeeRepository.GetEmployeeAsync(employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            //convert this data model that we stored in the employee variable to a domain model and return it to the angular application
            return Ok(mapper.Map<Employee>(employee));
        }

        [HttpPut]
        [Route("[controller]/{employeeId:guid}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid employeeId, [FromBody] UpdateEmployeeRequest newEmployeeInfo)
        {
            if(await employeeRepository.Exists(employeeId)) 
            {
                //update employee info
                var updatedEmployee = await employeeRepository.UpdateEmployee(employeeId, mapper.Map<DataModels.Employee>(newEmployeeInfo));

                if(updatedEmployee != null)
                {
                    return Ok(mapper.Map<Employee>(updatedEmployee));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[controller]/{employeeId:guid}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] Guid employeeId)
        {
            if (await employeeRepository.Exists(employeeId))
            {
                //delete employee
                var employee = await employeeRepository.DeleteEmployee(employeeId);
                return Ok(mapper.Map<Employee>(employee));
            }

            return NotFound();
        }
            
    }
}
