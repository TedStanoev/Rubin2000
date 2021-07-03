using Rubin2000.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rubin2000.Services.ForOccupations
{
    public interface IOccupationService
    {
        IEnumerable<Occupation> GetAllOccupations();

        Occupation GetOccupation(string id);
    }
}
