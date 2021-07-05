﻿using Rubin2000.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForProcedures
{
    public interface IProcedureService
    {
        IEnumerable<Procedure> GetAllProcedures();

        Procedure GetProcedure(string id);

        IEnumerable<Procedure> GetHairProcedures();

        IEnumerable<Procedure> GetNailsProcedures();
    }
}