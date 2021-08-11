using Rubin2000.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rubin2000.WebTests.Data
{
    public static class ServicesControllerData
    {
        public static IEnumerable<Procedure> HairProcedures()
        {
            var occupation = new Occupation { Name = Global.OccupationConstants.HairStyler };

            return Enumerable.Range(0, 6)
                .Select(p => new Procedure 
                {
                    Occupation = occupation
                });
        }

        public static IEnumerable<Procedure> NailProcedures()
        {
            var occupation = new Occupation { Name = Global.OccupationConstants.Manicurist };

            return Enumerable.Range(0, 4)
                .Select(p => new Procedure
                {
                    Occupation = occupation
                });
        }
    }
}
