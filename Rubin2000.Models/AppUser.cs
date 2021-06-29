using Microsoft.AspNetCore.Identity;
using Rubin2000.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Appointments = new HashSet<Appointment>();
        }

        [Required]
        [MaxLength(NameDefaultLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(NameDefaultLength)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
