using P01_StudentSystem.Data.Models.enumerations;

namespace P01_StudentSystem.Data.Models
{
    public class HomeworkSubmission
    {
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        public double SubmissionTime { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
