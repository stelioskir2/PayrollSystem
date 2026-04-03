using Microsoft.EntityFrameworkCore;
using PayrollSystem.Models;

namespace PayrollSystem.Data  
{
    public class PayrollContext : DbContext
    {
        public PayrollContext(DbContextOptions<PayrollContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("CITIES");
            modelBuilder.Entity<City>().Property(c => c.Id).HasColumnName("ID");
            modelBuilder.Entity<City>().Property(c => c.Name).HasColumnName("NAME");

            modelBuilder.Entity<Branch>().ToTable("BRANCHES");
            modelBuilder.Entity<Branch>().Property(b => b.Id).HasColumnName("ID");
            modelBuilder.Entity<Branch>().Property(b => b.Area).HasColumnName("AREA");
            modelBuilder.Entity<Branch>().Property(b => b.CityId).HasColumnName("CITY_ID");

            modelBuilder.Entity<Position>().ToTable("POSITIONS");
            modelBuilder.Entity<Position>().Property(p => p.Id).HasColumnName("ID");
            modelBuilder.Entity<Position>().Property(p => p.Title).HasColumnName("TITLE");

            modelBuilder.Entity<Employee>().ToTable("EMPLOYEES");
            modelBuilder.Entity<Employee>().Property(e => e.RegistrationNumber).HasColumnName("REGISTRATION_NUMBER");
            modelBuilder.Entity<Employee>().Property(e => e.FirstName).HasColumnName("FIRST_NAME");
            modelBuilder.Entity<Employee>().Property(e => e.LastName).HasColumnName("LAST_NAME");
            modelBuilder.Entity<Employee>().Property(e => e.BranchId).HasColumnName("BRANCH_ID");
            modelBuilder.Entity<Employee>().Property(e => e.PositionId).HasColumnName("POSITION_ID");
            modelBuilder.Entity<Employee>().Property(e => e.Salary).HasColumnName("SALARY").HasColumnType("NUMBER(10,2)");
            modelBuilder.Entity<Employee>().Property(e => e.Address).HasColumnName("ADDRESS");
            modelBuilder.Entity<Employee>().Property(e => e.Phone).HasColumnName("PHONE");
        }
    }
}