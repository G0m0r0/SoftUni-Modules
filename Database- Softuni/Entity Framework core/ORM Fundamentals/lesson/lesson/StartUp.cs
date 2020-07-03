using lesson.Models;
using System;
using System.Linq;

namespace lesson
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dbContext = new SoftuniContext();

            var employees = dbContext.Employees
                   .Where(x => x.Department.Manager.Department.Name == "Sales")
                   .Select(x => new
                   {
                       Name = x.FirstName + ' ' + x.LastName,
                       DepartmentName = x.Department.Name,
                       Manager = x.Manager.LastName
                   });


            foreach (var employee in employees)
            {
                Console.WriteLine($"Name: {employee.Name} in department: {employee.DepartmentName} with manager: {employee.Manager}");
            }


            //all employees

            var employeesAll = dbContext.Employees.ToList();

            foreach (var employee in employeesAll)
            {
                Console.WriteLine($"{employee.FirstName}  {employee.LastName}");
            }
        }
    }
}
