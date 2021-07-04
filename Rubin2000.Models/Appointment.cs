using Rubin2000.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Models
{
    public class Appointment
    {
        public Appointment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        [MaxLength(IdDefaultLength)]
        public string Id { get; set; }

        public DateTime DateAndTime { get; set; }

        [MaxLength(DescriptionDefaultLength)]
        public string Description { get; set; }

        public AppointmentStatus Status { get; set; }

        [Required]
        public string ClientId { get; set; }

        public AppUser Client { get; set; }

        public string ScheduleId { get; set; }

        public Schedule Schedule { get; set; }

        public string ProcedureId { get; set; }

        public Procedure Procedure { get; set; }
    }
}
