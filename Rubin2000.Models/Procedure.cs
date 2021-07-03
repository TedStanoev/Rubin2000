using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Rubin2000.Models.Enums;

using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Models
{
    public class Procedure
    {
        public Procedure()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Appointments = new HashSet<Appointment>();
        }

        [Key]
        [Required]
        [MaxLength(IdDefaultLength)]
        public string Id { get; set; }

        [Required]
        [MaxLength(OccupationNameDefaultLength)]
        public string Name { get; set; }

        public Duration Duration { get; set; }

        public decimal Price { get; set; }

        public decimal? PercantageDiscount { get; set; }

        [Required]
        public string OccupationId { get; set; }

        public Occupation Occupation { get; set; }

        public string CategoryId { get; set; }

        public ProcedureCategory Category { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
