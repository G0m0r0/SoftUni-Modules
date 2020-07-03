using Code_First_model.Models;
using System;
using System.Linq;

namespace Code_First_model
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dbContext = new StudentsDbContex();

            dbContext.Database.EnsureCreated();
            dbContext.Courses.Add(new Course { Name = "Entity Framework core" });
            dbContext.SaveChanges();

            //change 
            Course course = dbContext.Courses.FirstOrDefault(x => x.Id == 1);
            course.Name = "New name";
            dbContext.SaveChanges();

            //
            dbContext.Students.Add(new Student() { FirstName = "Nikolay", LastName = "Petrov" });
            dbContext.SaveChanges();

            //
            Console.WriteLine(dbContext.Students.Count(x=>x.FirstName=="Nikolay"));

            //add
            dbContext.Grades.Add(new Grade
            {
                Student = new Student { FirstName = "Stoyan", LastName = "Shopov" },
                Course = new Course { Name = "C# OOP" },
                Gradea = 6.00,
            });

            //update
            var grade = dbContext.Grades.FirstOrDefault(x => x.Student.FirstName == "Stoyan");

            grade.Gradea = 2;
            dbContext.SaveChanges();

            //delete
            dbContext.Grades.Remove(grade);


           
        }
    }
}
