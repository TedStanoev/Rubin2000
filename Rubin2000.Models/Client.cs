using Rubin2000.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubin2000.Models
{
    public class Client
    {
        public Client()
        {
            this.Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ClientAdditionalInfo { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}
