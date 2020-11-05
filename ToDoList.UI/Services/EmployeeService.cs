using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoListWebApi.Models;

namespace ToDoList.UI.Services
{
    public class EmployeeService : IEmployeeRespo
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _httpClient.GetJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetListOfEmployees()
        {
            return await _httpClient.GetJsonAsync<Employee[]>("api/employees");
        }
    }
}
