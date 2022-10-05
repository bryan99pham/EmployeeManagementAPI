using EmployeeManagementAppAPI.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementAppAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeAsync(Guid employeeId);
        Task<List<Department>>GetDepartmentsAsync();
        Task<bool>Exists(Guid employeeId);
        Task<Employee> UpdateEmployee(Guid employeeId, Employee newEmployeeInfo);
    }
}
