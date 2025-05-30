using HrApp.DomainEntities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HrAppWebApplication
{
    public class HrAppDbContext : DbContext
    {
        public HrAppDbContext(DbContextOptions<HrAppDbContext> options)
            : base(options)
        {
        }

        // Existing DbSets
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDossier> EmployeeDossiers { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        public DbSet<GeneratedDocument> GeneratedDocuments { get; set; }

        // Add User DbSet
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Department configuration (existing)
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.DepartmentID);
                entity.Property(d => d.Name).IsRequired().HasMaxLength(100);
                entity.Property(d => d.Description).HasMaxLength(500);
            });

            // Employee configuration (existing)
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(e => e.HireDate).IsRequired();
                entity.Property(e => e.Position).HasMaxLength(100);

                entity.HasOne(e => e.Department)
                    .WithMany(d => d.Employees)
                    .HasForeignKey(e => e.DepartmentID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Manager)
                    .WithMany(m => m.Subordinates)
                    .HasForeignKey(e => e.ManagerID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Mentor)
                    .WithMany(m => m.Mentees)
                    .HasForeignKey(e => e.MentorID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // User configuration (new)
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");

                // Relationship with Employee
                entity.HasOne(u => u.Employee)
                    .WithOne()
                    .HasForeignKey<User>(u => u.EmployeeID)
                    .OnDelete(DeleteBehavior.Cascade);

                // Ensure EmployeeID is unique
                entity.HasIndex(u => u.EmployeeID).IsUnique();
            });

            // EmployeeDossier configuration (existing)
            modelBuilder.Entity<EmployeeDossier>(entity =>
            {
                entity.HasKey(d => d.DossierID);

                entity.HasOne(d => d.Employee)
                    .WithOne(e => e.EmployeeDossier)
                    .HasForeignKey<EmployeeDossier>(d => d.EmployeeID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(d => d.BirthDate).IsRequired(false);
                entity.Property(d => d.Address).HasMaxLength(255);
                entity.Property(d => d.EmergencyContact).HasMaxLength(100);

                entity.Property(d => d.EmploymentType)
                    .HasMaxLength(50)
                    .HasConversion<string>();
            });

            // LeaveRequest configuration (existing)
            modelBuilder.Entity<LeaveRequest>(entity =>
            {
                entity.HasKey(l => l.RequestID);

                entity.HasOne(l => l.Employee)
                    .WithMany(e => e.LeaveRequests)
                    .HasForeignKey(l => l.EmployeeID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(l => l.StartDate).IsRequired();
                entity.Property(l => l.EndDate).IsRequired();

                entity.Property(l => l.LeaveType)
                    .HasMaxLength(50)
                    .HasConversion<string>();

                entity.Property(l => l.Status)
                    .HasMaxLength(20)
                    .HasDefaultValue("Pending")
                    .HasConversion<string>();

                entity.Property(l => l.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");
            });

            // Asset configuration (existing)
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.HasKey(a => a.AssetID);

                entity.HasOne(a => a.Employee)
                    .WithMany(e => e.Assets)
                    .HasForeignKey(a => a.EmployeeID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(a => a.Name).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Description).HasMaxLength(500);
                entity.Property(a => a.SerialNumber).HasMaxLength(100);
                entity.HasIndex(a => a.SerialNumber).IsUnique();

                entity.Property(a => a.AssignmentDate).HasDefaultValueSql("GETDATE()");
                entity.Property(a => a.IsActive).HasDefaultValue(true);
            });

            // DocumentTemplate configuration (existing)
            modelBuilder.Entity<DocumentTemplate>(entity =>
            {
                entity.HasKey(t => t.TemplateID);

                entity.Property(t => t.TemplateName).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Description).HasMaxLength(500);
                entity.Property(t => t.TemplateContent).IsRequired();

                entity.Property(t => t.TemplateType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            // GeneratedDocument configuration (existing)
            modelBuilder.Entity<GeneratedDocument>(entity =>
            {
                entity.HasKey(g => g.DocumentID);

                entity.HasOne(g => g.Employee)
                    .WithMany(e => e.GeneratedDocuments)
                    .HasForeignKey(g => g.EmployeeID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(g => g.DocumentTemplate)
                    .WithMany(t => t.GeneratedDocuments)
                    .HasForeignKey(g => g.TemplateID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(g => g.Content).IsRequired();
                entity.Property(g => g.GeneratedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(g => g.AssetIDs).HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}