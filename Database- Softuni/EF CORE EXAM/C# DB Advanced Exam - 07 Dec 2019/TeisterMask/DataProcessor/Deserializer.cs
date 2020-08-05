namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.XmlHelper;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var projectDtos = XmlConverter.Deserializer<ProjectDTO>(xmlString, "Projects");

            var projects = new List<Project>();
            var sb = new StringBuilder();

            foreach (ProjectDTO projectDto in projectDtos)
            {
                // Project

                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //valid open date
                DateTime projectOpenDate;
                bool isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                if(!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //valid due date
                DateTime? projectDueDate;
                if (!string.IsNullOrEmpty(projectDto.DueDate))
                {
                    //if we receive date
                    DateTime projectDueDateValue;
                    bool isProjectDueDateValid= DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDateValue);

                    if (!isProjectDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                    }

                    projectDueDate = projectDueDateValue;
                }
                else
                {
                    //if we dont receive date
                    projectDueDate = null;
                }

                var pr = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };

                //validate task
                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var checkExecutionType = Enum.IsDefined(typeof(ExecutionType), taskDto.ExecutionType);
                    var checkLabelType = Enum.IsDefined(typeof(LabelType), taskDto.LabelType);

                    //is task open date valid
                    DateTime taskOpenDate;
                    bool istaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    if (!istaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //is task duedate valid
                    DateTime taskDueDate;
                    bool isTaskDueDateDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isTaskDueDateDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //check for open date
                   if (taskOpenDate < projectOpenDate)
                   {
                       sb.AppendLine(ErrorMessage);
                       continue;
                   }

                   //check for due date
                   if(projectDueDate.HasValue)
                    {
                        if (taskDueDate > projectDueDate.Value)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                    var task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType,
                    };

                    pr.Tasks.Add(task);
                }

                projects.Add(pr);
                sb.AppendLine(string.Format(SuccessfullyImportedProject,pr.Name,pr.Tasks.Count()));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesJSON = JsonConvert.DeserializeObject<EmployeeDTO[]>(jsonString);

            var employeesForAdd = new List<Employee>();
            //var employeesTaskForAdd = new List<EmployeeTask>();
            var sb = new StringBuilder();

            foreach (EmployeeDTO e in employeesJSON)
            {
                if (!IsValid(e))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var newEmployee = new Employee
                {
                    Username = e.Username,
                    Email = e.Email,
                    Phone = e.Phone
                };

                foreach (int taskId in e.Tasks.Distinct())
                {
                    Task task = context.Tasks.FirstOrDefault(t => t.Id == taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var employeeTask = new EmployeeTask
                    {
                        Employee = newEmployee,
                        Task = task,
                    };

                    newEmployee.EmployeesTasks.Add(employeeTask);
                }

                employeesForAdd.Add(newEmployee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, newEmployee.Username, newEmployee.EmployeesTasks.Count()));
            }

            context.Employees.AddRange(employeesForAdd); //automatically adds employeesTasks
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsUsernameValid(string username)
        {
            foreach (var ch in username)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}