using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWebApi.Models;

namespace ToDoListWebApi.SQLData
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> opt)
            : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>(buildAction: builder =>
             {
                 builder.HasData(
                     new Department()
                     {
                         DepartmentId = 1,
                         DepartmentName = "IT"
                     },
                     new Department()
                     {
                         DepartmentId = 2,
                         DepartmentName = "HR"
                     },
                      new Department()
                      {
                          DepartmentId = 3,
                          DepartmentName = "Payroll"
                      },
                       new Department()
                       {
                           DepartmentId = 4,
                           DepartmentName = "Management"
                       }
                     );
             });
        }
    }
}
