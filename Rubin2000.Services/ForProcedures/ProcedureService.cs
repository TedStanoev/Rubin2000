using Rubin2000.Data;
using Rubin2000.Models;
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
            => data.Procedures.ToList();

        public Procedure GetProcedure(string id)
            => data.Procedures
            .Where(p => p.Id == id)
            .FirstOrDefault();
    }
}
