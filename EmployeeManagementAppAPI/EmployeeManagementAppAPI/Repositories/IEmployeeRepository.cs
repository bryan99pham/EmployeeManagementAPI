using EmployeeManagementAppAPI.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementAppAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
    }
}
