using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.UI.Services;
using ToDoListWebApi.Models;

namespace ToDoList.UI.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRespo _employeeRespository;
        public IEnumerable<Employee> Employees { get; set; }
        public IndexModel(IEmployeeRespo employeeRespository)
        {
            _employeeRespository = employeeRespository;
        }
        public async Task OnGet()
        {
            Employees = await _employeeRespository.GetListOfEmployees();
           
        }
    }
}
