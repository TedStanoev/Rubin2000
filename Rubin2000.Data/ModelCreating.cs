using Microsoft.EntityFrameworkCore;
using Rubin2000.Models;

namespace Rubin2000.Data
{
    public static class ModelCreating
    {
        public static void SetAppointmentKeys(ModelBuilder builder)
        {
            builder.Entity<Appointment>()
                .HasOne(k => k.Client)
                .WithMany(k => k.Appointments)
                .HasForeignKey(k => k.ClientId);
        }

        public static void SetEmployeeKeys(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasOne(e => e.Schedule)
                .WithOne(e => e.Employee)
                .HasForeignKey<Schedule>(s => s.EmployeeId);
        }

        public static void SetScheduleKeys(ModelBuilder builder)
        {
            builder.Entity<Schedule>()
                .HasOne(e => e.Employee)
                .WithOne(e => e.Schedule)
                .HasForeignKey<Employee>(s => s.ScheduleId);
        }

        public static void SetProcedureCategoryKeys(ModelBuilder builder)
        {
            builder.Entity<ProcedureCategory>()
                .HasMany(pc => pc.Procedures)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
