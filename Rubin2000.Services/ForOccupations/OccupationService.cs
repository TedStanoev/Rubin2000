using Rubin2000.Data;
using Rubin2000.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rubin2000.Services.ForOccupations
{
    public class OccupationService : IOccupationService
    {
        private readonly Rubin2000DbContext data;

        public OccupationService(Rubin2000DbContext data)
        {
            this.data = data;
        }

        public IEnumerable<Occupation> GetAllOccupations()
            => this.data.Occupations
                .ToList();

        public Occupation GetOccupation(string id)
            => this.data.Occupations
                .Where(o => o.Id == id)
                .FirstOrDefault();
    }
}
