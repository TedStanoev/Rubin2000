using Rubin2000.Models;
using Rubin2000.Services.ForProcedures.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForProcedures
{
    public interface IProcedureService
    {
        IEnumerable<ProcedureListServiceModel> GetHairProcedures();

        IEnumerable<ProcedureListServiceModel> GetNailsProcedures();

        bool ProcedureExists(string id);

        string GetProcedureName(string id);

        string GetPrcedureCategoryName(string id);
    }
}
