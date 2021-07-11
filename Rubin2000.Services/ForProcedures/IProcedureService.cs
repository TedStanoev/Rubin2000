using Rubin2000.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForProcedures
{
    public interface IProcedureService
    {
        IEnumerable<Procedure> GetAllProcedures();

        Procedure GetProcedure(string id);

        Procedure GetProcedureByName(string name);

        IEnumerable<Procedure> GetHairProcedures();

        IEnumerable<Procedure> GetNailsProcedures();

        bool ProcedureExists(string id);
    }
}
