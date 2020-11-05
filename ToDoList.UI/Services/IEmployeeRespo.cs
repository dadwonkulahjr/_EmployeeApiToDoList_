using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWebApi.Models;

namespace ToDoList.UI.Services
{
    public interface IEmployeeRespo
    {
        Task<IEnumerable<Employee>> GetListOfEmployees();
        Task<Employee> GetEmployeeById(int id);
      
    }
}
