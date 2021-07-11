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

        public Occupation GetEmployeeOccupation(string employeeId)
            => this.data.Occupations
                .Where(o => o.Employees.Any(e => e.Id == employeeId))
                .FirstOrDefault();

        public Occupation GetProcedureOccupation(string procedureId)
            => this.data.Occupations
                .Where(o => o.Procedures.Any(p => p.Id == procedureId))
                .FirstOrDefault();
    }
}
