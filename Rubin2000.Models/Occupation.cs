using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Models
{
    public class Occupation
    {
        public Occupation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Procedures = new HashSet<Procedure>();
            this.Employees = new HashSet<Employee>();
        }

        [Key]
        [Required]
        [MaxLength(IdDefaultLength)]
        public string Id { get; set; }

        [Required]
        [MaxLength(OccupationNameDefaultLength)]
        public string Name { get; set; }

        public ICollection<Procedure> Procedures { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
