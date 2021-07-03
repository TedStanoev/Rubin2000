using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Models
{
    public class ProcedureCategory
    {
        public ProcedureCategory()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Procedures = new HashSet<Procedure>();
        }

        [Key]
        [Required]
        [MaxLength(IdDefaultLength)]
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Procedure> Procedures { get; set; }
    }
}
