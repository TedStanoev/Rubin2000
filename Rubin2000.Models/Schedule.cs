using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Models
{
    public class Schedule
    {
        public Schedule()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Appointments = new HashSet<Appointment>();
        }

        [Key]
        [Required]
        [MaxLength(IdDefaultLength)]
        public string Id { get; set; }

        [MaxLength(DescriptionDefaultLength)]
        public string Description { get; set; }

        public DateTime StartsAt { get; set; }

        public DateTime EndsAt { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public Employee Employee { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
