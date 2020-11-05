using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWebApi.Models;
using ToDoListWebApi.SQLData;

namespace ToDoListWebApi.Services
{
    public class SQLService : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public SQLService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Employee> Commit(Employee employee)
        {
            await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Delete(int id)
        {
            var employeeFound = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if(employeeFound != null)
            {
                _appDbContext.Employees.Remove(employeeFound);
                await _appDbContext.SaveChangesAsync();
                return employeeFound;
            }

            return null;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _appDbContext.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> employeeQuery = _appDbContext.Employees;
            if (!string.IsNullOrEmpty(name))
            {
                employeeQuery = employeeQuery
                                    .Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            if(gender != null)
            {
                employeeQuery = employeeQuery.Where(e => e.Gender == gender);
            }

            return await employeeQuery.ToListAsync();
        }

        public async Task<Employee> Update(Employee employeeChanges)
        {
            var findEmployee = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeChanges.Id);
            if(findEmployee != null)
            {
                findEmployee.FirstName = employeeChanges.FirstName;
                findEmployee.LastName = employeeChanges.LastName;
                findEmployee.Gender = employeeChanges.Gender;
                findEmployee.Email = employeeChanges.Email;
                findEmployee.Salary = employeeChanges.Salary;
                findEmployee.DepartmentId = employeeChanges.DepartmentId;
                return findEmployee;
            }

            return null;
        }
    }
}
