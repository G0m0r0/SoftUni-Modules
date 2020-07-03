using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lesson.Models
{
    public partial class SoftuniContext : DbContext
    {
        public SoftuniContext()
        {
        }

        public SoftuniContext(DbContextOptions<SoftuniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EmployeesProjects> EmployeesProjects { get; set; }
        public virtual DbSet<EmployeesWithHighSalaries> EmployeesWithHighSalaries { get; set; }
        public virtual DbSet<Names> Names { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }
        public virtual DbSet<VEmployeeNameJobTitle> VEmployeeNameJobTitle { get; set; }
        public virtual DbSet<VEmployeesHiredAfter2000> VEmployeesHiredAfter2000 { get; set; }
        public virtual DbSet<VEmployeesSalaries> VEmployeesSalaries { get; set; }
        public virtual DbSet<VGetHireDateAndDayOfWeek> VGetHireDateAndDayOfWeek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Softuni;Integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(x => x.AddressId);

                entity.Property(e => e.AddressId)
                    .HasColumnName("AddressID")
                    .HasViewColumnName("AddressID");

                entity.Property(e => e.AddressText)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TownId)
                    .HasColumnName("TownID")
                    .HasViewColumnName("TownID");

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(x => x.TownId)
                    .HasConstraintName("FK_Addresses_Towns");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(x => x.DepartmentId);

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasViewColumnName("DepartmentID");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("ManagerID")
                    .HasViewColumnName("ManagerID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(x => x.ManagerId)
                    .HasConstraintName("FK_Departments_Employees");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(x => x.EmployeeId);

                entity.HasIndex(x => new { x.FirstName, x.LastName });

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasViewColumnName("EmployeeID");

                entity.Property(e => e.AddressId)
                    .HasColumnName("AddressID")
                    .HasViewColumnName("AddressID");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasViewColumnName("DepartmentID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate).HasColumnType("smalldatetime");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId)
                    .HasColumnName("ManagerID")
                    .HasViewColumnName("ManagerID");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(x => x.AddressId)
                    .HasConstraintName("FK_Employees_Addresses");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departments");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(x => x.ManagerId)
                    .HasConstraintName("FK_Employees_Employees");
            });

            modelBuilder.Entity<EmployeesProjects>(entity =>
            {
                entity.HasKey(x => new { x.EmployeeId, x.ProjectId });

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasViewColumnName("EmployeeID");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasViewColumnName("ProjectID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeesProjects)
                    .HasForeignKey(x => x.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeesProjects_Employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EmployeesProjects)
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeesProjects_Projects");
            });

            modelBuilder.Entity<EmployeesWithHighSalaries>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AddressId)
                    .HasColumnName("AddressID")
                    .HasViewColumnName("AddressID");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasViewColumnName("DepartmentID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasViewColumnName("EmployeeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate).HasColumnType("smalldatetime");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId)
                    .HasColumnName("ManagerID")
                    .HasViewColumnName("ManagerID");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            modelBuilder.Entity<Names>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(x => x.ProjectId);

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasViewColumnName("ProjectID");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Towns>(entity =>
            {
                entity.HasKey(x => x.TownId);

                entity.Property(e => e.TownId)
                    .HasColumnName("TownID")
                    .HasViewColumnName("TownID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VEmployeeNameJobTitle>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_EmployeeNameJobTitle");

                entity.Property(e => e.FullName)
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VEmployeesHiredAfter2000>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_EmployeesHiredAfter2000");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VEmployeesSalaries>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_EmployeesSalaries");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            modelBuilder.Entity<VGetHireDateAndDayOfWeek>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_GetHireDateAndDayOfWeek");

                entity.Property(e => e.DayOfWeek).HasMaxLength(30);

                entity.Property(e => e.HireDate).HasColumnType("smalldatetime");
            });

            modelBuilder.HasSequence<int>("seq_MyNumber")
                .StartsAt(0)
                .IncrementsBy(1001);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
