namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
            HomeworkSubmissions = new HashSet<HomeworkSubmission>();
            StudentCourses = new HashSet<StudentCourse>();
        }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime RegisteredOn { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
