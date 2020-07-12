namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;
    public class StudentSystemContext:DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            :base(options)
        {
       
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(c => c.Description)
                .IsRequired(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.PhoneNumber)
                 .IsUnicode(false)
                 .IsRequired(false);

                entity.Property(s => s.Birthday)
                .IsUnicode(false);

            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(r => r.ResourceType)
                 .IsUnicode(false);

                entity.Property(r => r.Url)
                .IsRequired(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(h => h.Content)
                .IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.CourseId, sc.StudentId });
            });
        }

    }
}
