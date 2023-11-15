using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentsApp.Models;

public partial class DevDbContext : DbContext
{
    public DevDbContext()
    {
    }

    public DevDbContext(DbContextOptions<DevDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClassDetail> ClassDetails { get; set; }

    public virtual DbSet<CurricularUnit> CurricularUnits { get; set; }

    public virtual DbSet<Objective> Objectives { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=dev-db;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ClassDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Class_Details");

            entity.HasIndex(e => e.FkIdTeacher, "fk_Class_Details_1_idx");

            entity.Property(e => e.FkIdTeacher).HasColumnName("fkIdTeacher");
            entity.Property(e => e.StrName)
                .HasMaxLength(150)
                .HasColumnName("strName");
            entity.Property(e => e.StrYear)
                .HasMaxLength(9)
                .HasColumnName("strYear");

            entity.HasOne(d => d.FkIdTeacherNavigation).WithMany(p => p.ClassDetails)
                .HasForeignKey(d => d.FkIdTeacher)
                .HasConstraintName("fk_Class_Details_1");
        });

        modelBuilder.Entity<CurricularUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Curricular_Units");

            entity.HasIndex(e => e.FkIdCurricularUnit, "fk_Curricular_Units_1_idx");

            entity.Property(e => e.FkIdCurricularUnit).HasColumnName("fkIdCurricularUnit");
            entity.Property(e => e.StrName)
                .HasMaxLength(150)
                .HasColumnName("strName");

            entity.HasOne(d => d.FkIdCurricularUnitNavigation).WithMany(p => p.InverseFkIdCurricularUnitNavigation)
                .HasForeignKey(d => d.FkIdCurricularUnit)
                .HasConstraintName("fk_Curricular_Units_1");
        });

        modelBuilder.Entity<Objective>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.FkIdCurricularUnits, "fk_Objectives_1_idx");

            entity.Property(e => e.FkIdCurricularUnits).HasColumnName("fkIdCurricularUnits");
            entity.Property(e => e.StrLabel)
                .HasMaxLength(250)
                .HasColumnName("strLabel");

            entity.HasOne(d => d.FkIdCurricularUnitsNavigation).WithMany(p => p.Objectives)
                .HasForeignKey(d => d.FkIdCurricularUnits)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Objectives_1");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.FkIdRoles, "fk_People_1_idx");

            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.FkIdRoles).HasColumnName("fkIdRoles");
            entity.Property(e => e.LastName).HasMaxLength(150);

            entity.HasOne(d => d.FkIdRolesNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.FkIdRoles)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_People_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.StrDescription)
                .HasMaxLength(45)
                .HasColumnName("strDescription");
            entity.Property(e => e.StrLabel)
                .HasMaxLength(100)
                .HasColumnName("strLabel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
