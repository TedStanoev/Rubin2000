using System;
using System.ComponentModel.DataAnnotations;
using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        [MaxLength(IdDefaultLength)]
        public string Id { get; set; }

        [Required]
        [MaxLength(NameDefaultLength)]
        public string Name { get; set; }

        [Required]
        public string OccupationId { get; set; }

        [Required]
        public Occupation Occupation { get; set; }

        public string ScheduleId { get; set; }

        public Schedule Schedule { get; set; }
    }
}
