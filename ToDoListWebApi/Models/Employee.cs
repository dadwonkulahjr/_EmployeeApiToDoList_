using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListWebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Column(TypeName ="decimal(18,0)")]
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        public int DepartmentId { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
