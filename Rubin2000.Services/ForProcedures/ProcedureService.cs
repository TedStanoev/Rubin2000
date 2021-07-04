using Microsoft.EntityFrameworkCore;
using Rubin2000.Data;
using Rubin2000.Models;
using Rubin2000.Services.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Rubin2000.Services.ForProcedures
{
    public class ProcedureService : IProcedureService
    {
        private readonly Rubin2000DbContext data;

        public ProcedureService(Rubin2000DbContext data)
        {
            this.data = data;
        }

        public IEnumerable<Procedure> GetAllProcedures()
            => this.data.Procedures
                .Include(p => p.Occupation)
                .Include(p => p.Category)
                .ToList();

        public IEnumerable<Procedure> GetHairProcedures()
            => this.data.Procedures
                .Where(p => p.Occupation.Name.ToLower() == OccupationConstants.HairStyler)
                .Include(p => p.Occupation)
                .Include(p => p.Category)
                .ToList();

        public IEnumerable<Procedure> GetNailsProcedures()
        => this.data.Procedures
                .Where(p => p.Occupation.Name.ToLower() == OccupationConstants.Manicurist)
                .Include(p => p.Occupation)
                .Include(p => p.Category)
                .ToList();

        public Procedure GetProcedure(string id)
            => this.data.Procedures
            .Where(p => p.Id == id)
            .FirstOrDefault();
    }
}
