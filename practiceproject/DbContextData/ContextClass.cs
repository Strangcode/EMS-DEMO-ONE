using Microsoft.EntityFrameworkCore;
using practiceproject.Models;

namespace practiceproject.DbContextData
{
    public class ContextClass : DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> options) : base(options)
        {

        }
        public DbSet<UserRegistration> RegisterUsers { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Attendance> Attendancess { get; set; }
        public DbSet<NewEmployee> NewEmployees { get; set; }
    }
}
