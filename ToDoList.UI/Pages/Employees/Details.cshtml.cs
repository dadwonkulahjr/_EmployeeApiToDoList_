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
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRespo _employeeRespo;
        public Employee Employee { get; set; }
        public DetailsModel(IEmployeeRespo employeeRespo)
        {
            _employeeRespo = employeeRespo;
        }
        public async Task<ActionResult> OnGet(int id)
        {
            Employee = await _employeeRespo.GetEmployeeById(id);
            return Page();
        }
    }
}
