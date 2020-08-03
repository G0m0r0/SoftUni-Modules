namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Xml;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.XmlHelper;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .ToArray() //for judge
                .Where(x => x.Tasks.Count() > 0)
                .Select(x => new ProjectsWithTheirTasksDTO
                {
                    ProjectName = x.Name,
                    TasksCount = x.Tasks.Count(),
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(y => new TaskDTO
                    {
                        Name = y.Name,
                        Label = Enum.GetName(typeof(LabelType), y.LabelType)
                    }).OrderBy(y=>y.Name)
                    .ToArray()
                }).OrderByDescending(x=>x.TasksCount)
                .ThenBy(x=>x.ProjectName)
                .ToArray();

            var result = XmlConverter.Serialize(projects, "Projects");

            return result;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToArray()  //for judge
                .Where(x=>x.EmployeesTasks.Any(y=>y.Task.OpenDate>=date))
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks 
                                    .Where(y=>y.Task.OpenDate>=date)
                                    .Select(y => new
                                    {
                                        TaskName = y.Task.Name,
                                        OpenDate = y.Task.OpenDate.ToString("d",CultureInfo.InvariantCulture),
                                        DueDate = y.Task.DueDate.ToString("d",CultureInfo.InvariantCulture),
                                        LabelType = Enum.GetName(typeof(LabelType), y.Task.LabelType),
                                        ExecutionType =Enum.GetName(typeof(ExecutionType), y.Task.ExecutionType)
                                    }).OrderByDescending(y => DateTime.ParseExact(y.DueDate,"d",CultureInfo.InvariantCulture))
                                    .ThenBy(y => y.TaskName)
                                    .ToArray()
                }).OrderByDescending(x=>x.Tasks.Count())
                .ThenBy(x=>x.Username)
                .ToArray().Take(10);

            var result = JsonConvert.SerializeObject(employees,Formatting.Indented);

            return result;
        }
    }
}