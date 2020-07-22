using System;

namespace AuttoMapper
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using AuttoMapper.Models;
    using AuttoMapper.ViewModels;
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftuniContext();

            //_______________from db to class
            var config= new MapperConfiguration(cfg=>
            {
                cfg.AddProfile(new EmployeesToViewModelProfile());
            });
            IMapper mapper = config.CreateMapper();


            var employees = db.Employees.ProjectTo<EmployeeDepartment>(config).Take(10).ToList();

            // var employeeDep = mapper.Map<EmployeeDepartment>(employee);

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} in deparment {e.DepartmentName}");
            }


            //________________from class to db
            var inputModel = new EmployeeDepartment { DepartmentName = "New", FirstName = "Pesho" };
            var employee=mapper.Map<Employee>(inputModel);

            Console.WriteLine($"FirstName: {employee.FirstName}\nLastName: {employee.LastName}\nHireDate: {employee.HireDate}");
        }
    }
}
