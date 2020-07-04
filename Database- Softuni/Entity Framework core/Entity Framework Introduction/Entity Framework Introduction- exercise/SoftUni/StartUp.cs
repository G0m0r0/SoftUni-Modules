using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main()
        {
            var db = new SoftUniContext();
            //
            // var employeesInfo = GetEmployeesFullInformation(db);
            // 
            // Console.WriteLine(GetEmployeesWithSalaryOver50000(db));
            //
            // Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));
            //
            // Console.WriteLine(AddNewAddressToEmployee(db));
            //
            // Console.WriteLine(GetEmployeesInPeriod(db));
            //
            // Console.WriteLine(GetAddressesByTown(db));
            //
            // Console.WriteLine(GetEmployee147(db));
            //
            // Console.WriteLine(GetDepartmentsWithMoreThan5Employees(db));
            //
            // Console.WriteLine(GetLatestProjects(db));

            // Console.WriteLine(IncreaseSalaries(db));

            // Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(db));

            // Console.WriteLine(DeleteProjectById(db));

            Console.WriteLine(RemoveTown(db));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.OrderBy(x => x.EmployeeId).ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {(e.Salary):F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Where(x => x.Salary > 50000).OrderBy(x => x.FirstName);

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {(e.Salary):F2} {e.Department.Name}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context
                   .Employees
                   .Where(x => x.Department.Name == "Research and Development")
                   .Select(e => new
                   {
                       e.FirstName,
                       e.LastName,
                       e.Salary
                   })
                   .OrderBy(x => x.Salary)
                   .ThenByDescending(x => x.FirstName)
                   .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - ${e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            Employee employeeNakov = context.Employees.First(e => e.LastName == "Nakov");

            employeeNakov.Address = newAddress;
            //or
            //context.Addresses.Add(newAddress);

            context.SaveChanges();

            var addresses = context.Employees.OrderByDescending(e => e.AddressId).Take(10).Select(e => e.Address.AddressText).ToList();


            var sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendLine(a);
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects
                   .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(n => new
                {
                    n.FirstName,
                    n.LastName,
                    managerFirstName = n.Manager.FirstName,
                    managerLastName = n.Manager.LastName,
                    project = n.EmployeesProjects.Select(ep =>
                                              new
                                              {
                                                  ProjectName = ep.Project.Name,
                                                  StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                                  EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                                              })
                    .ToList(),
                });


            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.managerFirstName} {e.managerLastName}");

                foreach (var p in e.project)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(c => c.Employees.Count())
                .ThenBy(t => t.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    address = a.AddressText,
                    name = a.Town.Name,
                    count = a.Employees.Count()
                }).ToList();

            var sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.address}, {a.name} - {a.count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(ep => ep.Project.Name).OrderBy(pn => pn).ToList()
                }).Single();

            sb.AppendLine($"{employee.FirstName} - {employee.LastName} {employee.JobTitle}");

            foreach (var p in employee.Projects)
            {
                sb.AppendLine(p);
            }

            return sb.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(x => x.Employees.Count() > 5)
                .OrderBy(x => x.Employees.Count())
                .ThenBy(x => x.Name);

            var depInfo = departments.Select(x => new
            {
                DepName = x.Name,
                MFirstName = x.Manager.FirstName,
                MLastName = x.Manager.LastName,
                Employees = x.Employees.Select(e => new { e.FirstName, e.LastName, e.JobTitle }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList(),
            }).ToList();

            var sb = new StringBuilder();

            foreach (var d in depInfo)
            {
                sb.AppendLine($"{d.DepName} - {d.MFirstName} {d.MLastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }


        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    startDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                }).ToList();

            var sb = new StringBuilder();
            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.startDate);
            }

            return sb.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            //Engineering, Tool Design, Marketing or Information Services 
            var employees = context.Employees
                .Where(x => x.Department.Name == "Engineering" ||
                        x.Department.Name == "Tool Design" ||
                        x.Department.Name == "Marketing" ||
                        x.Department.Name == "Information Services");

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employeesWithUpdatedSalaries = employees.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            }).OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName).ToList();

            foreach (var e in employeesWithUpdatedSalaries)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {

            var employees = context.Employees
                            .Where(e => e.FirstName.StartsWith("Sa") || e.FirstName.StartsWith("SA"))
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                e.JobTitle,
                                e.Salary
                            }).ToList();

            var sb = new StringBuilder();

            foreach (var e in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Find(2);
            var projectRef = context.EmployeesProjects.Where(r => r.Project == project).ToList();

            foreach (var pr in projectRef)
            {
                context.EmployeesProjects.Remove(pr);
            }
            context.Projects.Remove(project);
            context.SaveChanges();

            var projects = context.Projects.Take(10).Select(p => p.Name).ToList();

            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine(p);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var townToDel = context.Towns.First(x => x.Name == "Seattle");

            var addressToDelete = context.Addresses.Where(a => a.TownId == townToDel.TownId);

            int addressesCount = addressToDelete.Count();
            var employeesWithTownToDelete = context.Employees.Where(e => addressToDelete.Any(a => a.AddressId == e.AddressId));

            foreach (var e in employeesWithTownToDelete)
            {
                e.Address = null;
            }

            foreach (var address in addressToDelete)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(townToDel);
            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }
    }
}
