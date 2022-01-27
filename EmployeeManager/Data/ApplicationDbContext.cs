using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EmployeeProject> EmployeeProject { get; set; }
        public DbSet<JobHistoryPosition> JobHistoryPosition { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeProject>().HasKey(ep => new { ep.EmployeeId, ep.ProjectId });
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.JobHistory).WithOne(y => y.Employee)
                .HasForeignKey<JobHistory>(a => a.EmployeeId);
            modelBuilder.Entity<Manager>()
                .HasMany(x => x.Employees).WithOne(y => y.Manager)
                .HasForeignKey(a => a.ManagerId);
            modelBuilder.Entity<JobHistoryPosition>().HasKey(x => new { x.JobHistoryId, x.PositionId });
        }
    }
}