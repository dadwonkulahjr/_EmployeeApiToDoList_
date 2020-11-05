using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWebApi.Models;

namespace ToDoListWebApi.Services
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> Commit(Employee employee);
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
        Task<Employee> Delete(int id);
        Task<Employee> Update(Employee employeeChanges);
      
    }
}
