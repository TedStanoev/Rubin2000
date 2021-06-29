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

        public DbSet<AppointmentSchedule> AppointmentSchedules { get; set; }

        public DbSet<Occupation> Occupations { get; set; }

        public DbSet<AppointmentProcedure> AppointmentProcedures { get; set; }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppointmentSchedule>()
                .HasKey(k => new { k.AppointmentId, k.ScheduleId });

            builder.Entity<AppointmentSchedule>()
                .HasOne(k => k.Appointment)
                .WithMany(k => k.Schedules)
                .HasForeignKey(k => k.ScheduleId);

            builder.Entity<AppointmentSchedule>()
                .HasOne(k => k.Schedule)
                .WithMany(k => k.Appointments)
                .HasForeignKey(k => k.AppointmentId);

            builder.Entity<AppointmentProcedure>()
                .HasKey(k => new { k.AppointmentId, k.ProcedureId });

            builder.Entity<AppointmentProcedure>()
                .HasOne(k => k.Procedure)
                .WithMany(k => k.Appointments)
                .HasForeignKey(k => k.AppointmentId);

            builder.Entity<AppointmentProcedure>()
                .HasOne(k => k.Appointment)
                .WithMany(k => k.Procedures)
                .HasForeignKey(k => k.ProcedureId);

            builder.Entity<Appointment>()
                .HasOne(k => k.Client)
                .WithMany(k => k.Appointments)
                .HasForeignKey(k => k.ClientId);



        }
    }
}
