﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Schedules = new HashSet<Schedule>();
        }

        [Key]
        [Required]
        [MaxLength(IdDefaultLength)]
        public string Id { get; set; }

        [Required]
        [MaxLength(NameDefaultLength)]
        public string Name { get; set; }

        [Required]
        public Occupation Occupation { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}
