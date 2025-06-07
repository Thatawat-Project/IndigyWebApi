using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IndigyBackendTestAPI.Infrastructure.Db;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Comm).HasColumnName("COMM");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATE_DATE");
            entity.Property(e => e.Deptno).HasColumnName("DEPTNO");
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .HasColumnName("DESIGNATION");
            entity.Property(e => e.Empno)
                .HasMaxLength(5)
                .HasColumnName("EMPNO");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.Hiredate)
                .HasColumnType("datetime")
                .HasColumnName("HIREDATE");
            entity.Property(e => e.IsDelete).HasColumnName("IS_DELETE");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("SALARY");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
