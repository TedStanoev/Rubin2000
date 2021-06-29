using System.ComponentModel.DataAnnotations;

namespace Rubin2000.Models
{
    public class AppointmentProcedure
    {
        [Key]
        [Required]
        public string AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        [Key]
        [Required]
        public string ProcedureId { get; set; }

        public Procedure Procedure { get; set; }
    }
}
