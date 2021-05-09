using Microsoft.AspNetCore.Identity;
using Rubin2000.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubin2000.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Occupation Occupation { get; set; }

        public Gender Gender { get; set; }

        public WorkDays WorkDays { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public decimal BudgetPercentage { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}
