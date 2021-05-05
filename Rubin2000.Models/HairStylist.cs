using Microsoft.AspNetCore.Identity;
using Rubin2000.Models.Enums;
using System;
using System.Collections.Generic;

namespace Rubin2000.Models
{
    public class HairStylist
    {
        public HairStylist()
        {
            this.Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public WorkDays WorkDays { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public decimal BudgetPercentage { get; set; }

        public int UserId { get; set; }

        public IdentityUser User { get; set; }

    }
}
