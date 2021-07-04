using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rubin2000.Models;

namespace Rubin2000.Data
{
    public class Rubin2000DbContext : IdentityDbContext<IdentityUser>
    {
        public Rubin2000DbContext(DbContextOptions<Rubin2000DbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<Occupation> Occupations { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProcedureCategory> ProcedureCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ModelCreating.SetAppointmentKeys(builder);
        }
    }
}
