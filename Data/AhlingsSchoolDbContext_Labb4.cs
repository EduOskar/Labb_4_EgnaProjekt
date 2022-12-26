using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Labb_4_EgnaProjekt.Models;

namespace Labb_4_EgnaProjekt.Data
{
    public partial class AhlingsSchoolDbContext : DbContext
    {
        public AhlingsSchoolDbContext()
        {
        }

        public AhlingsSchoolDbContext(DbContextOptions<AhlingsSchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<GradingTable> GradingTables { get; set; } = null!;
        public virtual DbSet<PersonalInformation> PersonalInformations { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8KGH2CT; Initial Catalog = AhlingsSchool;Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassName).HasMaxLength(15);

                entity.Property(e => e.FkEmployeeId).HasColumnName("FK_EmployeeId");

                entity.Property(e => e.FkGradingTable).HasColumnName("FK_GradingTable");

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Classes_Employees");

                entity.HasOne(d => d.FkGradingTableNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.FkGradingTable)
                    .HasConstraintName("FK_Classes_gradingTables");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassId");

                entity.Property(e => e.FkPersonIdEmployee).HasColumnName("FK_PersonIdEmployee");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.Title).HasMaxLength(15);

                entity.HasOne(d => d.FkPersonIdEmployeeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.FkPersonIdEmployee)
                    .HasConstraintName("FK_Employees_personalInformations");
            });

            modelBuilder.Entity<GradingTable>(entity =>
            {
                entity.HasKey(e => e.GradingId);

                entity.ToTable("gradingTables");

                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassId");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentId");

                entity.Property(e => e.GradeSet).HasColumnType("date");

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.GradingTables)
                    .HasForeignKey(d => d.FkClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_gradingTables_Classes");

                entity.HasOne(d => d.FkStudent)
                    .WithMany(p => p.GradingTables)
                    .HasForeignKey(d => d.FkStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_gradingTables_Students");
            });

            modelBuilder.Entity<PersonalInformation>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("personalInformations");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .HasColumnName("FName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasMaxLength(20)
                    .HasColumnName("LName");

                entity.Property(e => e.Ssnumber)
                    .HasMaxLength(13)
                    .HasColumnName("SSNumber");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("schools");

                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassId");

                entity.Property(e => e.FkClassName)
                    .HasMaxLength(15)
                    .HasColumnName("FK_ClassName");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentId");

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.FkClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_schools_Classes");

                entity.HasOne(d => d.FkStudent)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.FkStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_schools_Students");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassId");

                entity.Property(e => e.FkPersonIdStudent).HasColumnName("FK_PersonIdStudent");

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FkClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Classes");

                entity.HasOne(d => d.FkPersonIdStudentNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FkPersonIdStudent)
                    .HasConstraintName("FK_Students_personalInformations1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
