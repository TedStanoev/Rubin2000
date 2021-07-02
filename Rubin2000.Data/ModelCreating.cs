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
    }
}
