using Microsoft.EntityFrameworkCore;
using Rubin2000.Models;

namespace Rubin2000.Data.ModelCreating
{
    public static class ModelCreator
    {
        public static void SetModelKeys(ModelBuilder builder)
        {
            SetAppointmentKeys(builder);
            SetScheduleKeys(builder);
            SetProcedureCategoryKeys(builder);
        }

        private static void SetAppointmentKeys(ModelBuilder builder)
        {
            builder.Entity<Appointment>()
                .HasOne(k => k.Creator)
                .WithMany(k => k.Appointments)
                .HasForeignKey(k => k.CreatorId);
        }

        private static void SetScheduleKeys(ModelBuilder builder)
        {
            builder.Entity<Schedule>()
                .HasOne(e => e.Employee)
                .WithOne(e => e.Schedule)
                .HasForeignKey<Employee>(s => s.ScheduleId);
        }

        private static void SetProcedureCategoryKeys(ModelBuilder builder)
        {
            builder.Entity<ProcedureCategory>()
                .HasMany(pc => pc.Procedures)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
