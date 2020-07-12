using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;

namespace P01_StudentSystem.Data
{
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
        public DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }
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
                entity.HasKey(c => c.CourseId);

                entity.Property(c => c.Description)
                .IsUnicode(true)
                .IsRequired(false);

                entity.Property(c => c.Name)
                .IsUnicode(true)
                .IsRequired(true)
                .HasMaxLength(80);

                entity.Property(c => c.EndDate)
                .IsRequired();

                entity.Property(c => c.StartDate)
                .IsRequired();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.Property(s => s.Name)
                .IsUnicode(true)
                .IsRequired(true)
                .HasMaxLength(100);

                entity.Property(s => s.PhoneNumber)
                .IsUnicode(false)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasMaxLength(10);

                entity.Property(s => s.Birthdate)
                .IsRequired();

                entity.Property(s => s.RegisteredOn)
                .IsRequired();
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity.Property(r => r.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

                entity.Property(r => r.Url)
                .IsUnicode(false);

                entity.HasOne(r => r.Course)
                .WithMany(r => r.Resources)
                .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<HomeworkSubmission>(entity =>
            {
                entity.HasKey(h => h.HomeworkId);

                entity.Property(h => h.Content)
                .IsRequired(true)
                .IsUnicode(false);

                entity.HasOne(h => h.Student)
                .WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(h => h.StudentId);

                entity.HasOne(h => h.Course)
                .WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.CourseId, sc.StudentId });

                entity.HasOne(sc => sc.Course)
                .WithMany(sc => sc.StudentCourses)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sc => sc.Student)
                .WithMany(sc => sc.StudentCourses)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }

    }
}
