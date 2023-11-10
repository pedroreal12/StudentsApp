﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace StudentsApp.Models;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClassDetail> ClassDetails { get; set; }

    public virtual DbSet<CurricularUnit> CurricularUnits { get; set; }

    public virtual DbSet<Objective> Objectives { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=School;Trusted_Connection=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class_De__3214EC070708EA46");

            entity.ToTable("Class_Details");

            entity.Property(e => e.FkIdCurricularUnits).HasColumnName("fkIdCurricularUnits");
            entity.Property(e => e.FkIdPerson).HasColumnName("fkIdPerson");
            entity.Property(e => e.StrName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("strName");
            entity.Property(e => e.StrYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("strYear");

            entity.HasOne(d => d.FkIdCurricularUnitsNavigation).WithMany(p => p.ClassDetails)
                .HasForeignKey(d => d.FkIdCurricularUnits)
                .HasConstraintName("FK__Class_Det__fkIdC__4D94879B");

            entity.HasOne(d => d.FkIdPersonNavigation).WithMany(p => p.ClassDetails)
                .HasForeignKey(d => d.FkIdPerson)
                .HasConstraintName("FK__Class_Det__fkIdP__4CA06362");
        });

        modelBuilder.Entity<CurricularUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curricul__3214EC07293D9EDB");

            entity.ToTable("Curricular_Units");

            entity.Property(e => e.StrName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("strName");
        });

        modelBuilder.Entity<Objective>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Objectiv__3214EC073F0E0D8B");

            entity.Property(e => e.FkIdCurricularUnits).HasColumnName("fkIdCurricularUnits");
            entity.Property(e => e.StrLabel)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("strLabel");

            entity.HasOne(d => d.FkIdCurricularUnitsNavigation).WithMany(p => p.Objectives)
                .HasForeignKey(d => d.FkIdCurricularUnits)
                .HasConstraintName("FK__Objective__fkIdC__49C3F6B7");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__People__3214EC07ECC9E390");

            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FkIdRoles).HasColumnName("fkIdRoles");
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.FkIdRolesNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.FkIdRoles)
                .HasConstraintName("FK__People__fkIdRole__44FF419A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07AB906171");

            entity.Property(e => e.StrDescription)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("strDescription");
            entity.Property(e => e.StrLabel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("strLabel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
