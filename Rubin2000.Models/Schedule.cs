using Rubin2000.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubin2000.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Appointment { get; set; }

        public Duration Duration { get; set; }

        public Procedure Procedure { get; set; }

        public decimal? PriceIncrease { get; set; }

        public decimal TotalPrice { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
