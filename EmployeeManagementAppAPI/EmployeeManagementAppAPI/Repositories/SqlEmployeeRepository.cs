using EmployeeManagementAppAPI.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeManagementAppAPI.Repositories
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementContext context;

        public SqlEmployeeRepository(EmployeeManagementContext context)
        {
            this.context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
           return await context.Employee.Include(nameof(Department)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(Guid employeeId)
        {
            return await context.Employee
                .Include(nameof(Department)).Include(nameof(Address))
                .FirstOrDefaultAsync(x => x.Id == employeeId);
        }

    }
}
