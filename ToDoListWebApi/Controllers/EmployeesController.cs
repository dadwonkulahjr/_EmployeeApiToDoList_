using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListWebApi.Models;
using ToDoListWebApi.Services;

namespace ToDoListWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<Employee>> GetEmployees()
        {
            try
            {
                var result = await _employeeRepository.GetAllEmployees();
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error displaying the data from the database!");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var employeeFound = await _employeeRepository.GetEmployeeById(id);
                if (employeeFound == null)
                {
                    return BadRequest($"The employee with Id = {id} cannot be found!");
                }

                return Ok(employeeFound);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "There were error in retrieving the data from the database!");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddNewEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                var employeeToBeCommitted = await _employeeRepository.Commit(employee);
                return base.CreatedAtAction(nameof(GetEmployee), new { id = employeeToBeCommitted.Id },
                    employeeToBeCommitted);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error in commiting the data from the database!");
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult<Employee> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.Id)
                {
                    return BadRequest("Employee Id mismatch");
                }
                var employeeToUpdate = _employeeRepository.GetEmployeeById(id);
                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with Id = {id} cannot be found!");
                }

                var empUpdated = _employeeRepository.Update(employee);
                return base.Ok(empUpdated);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error in updating the data from the database!");
            }
        }
        [HttpDelete("{id:int}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            try
            {
                var empFound = _employeeRepository.Delete(id);
                if (empFound == null)
                {
                    return NotFound($"Employee with Id = {id} cannot be found!");
                }
                return Ok(empFound);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error in deleting the data from the database!");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<Employee>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await _employeeRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error in searching for the data from the database!");
            }
        }

       

    }
}
