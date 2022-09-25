using Microsoft.EntityFrameworkCore;
using WebAppCRUD.Models;

namespace WebAppCRUD.Data
{
    public class DbCtxCRUD:DbContext
    {
        public DbCtxCRUD(DbContextOptions<DbCtxCRUD> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("Employees", "HR");
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
