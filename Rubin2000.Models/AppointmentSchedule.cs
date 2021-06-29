using System.ComponentModel.DataAnnotations;

namespace Rubin2000.Models
{
    public class AppointmentSchedule
    {
        [Key]
        [Required]
        public string AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        [Key]
        [Required]
        public string ScheduleId { get; set; }

        public Schedule Schedule { get; set; }
    }
}
