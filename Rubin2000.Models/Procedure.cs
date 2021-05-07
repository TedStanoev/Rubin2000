using Rubin2000.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubin2000.Models
{
    public class Procedure
    {
        public Procedure()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal? PercantageDiscount { get; set; }

        public Occupation Occupation { get; set; }
    }
}
