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
            this.IsDeletedToUser = false;
            this.IsEdited = false;
        }

        [Key]
        [Required]
        [MaxLength(IdDefaultLength)]
        public string Id { get; set; }

        public DateTime DateAndTime { get; set; }

        [Required]
        [MaxLength(NameDefaultLength)]
        public string ClientName { get; set; }

        [MaxLength(DescriptionDefaultLength)]
        public string Description { get; set; }

        public AppointmentStatus Status { get; set; }

        public bool IsDeletedToUser { get; set; }

        public bool IsEdited { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public AppUser Creator { get; set; }

        public string ScheduleId { get; set; }

        public Schedule Schedule { get; set; }

        public string ProcedureId { get; set; }

        public Procedure Procedure { get; set; }
    }
}
