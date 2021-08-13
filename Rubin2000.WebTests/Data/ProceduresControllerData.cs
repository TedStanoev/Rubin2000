using Rubin2000.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rubin2000.WebTests.Data
{
    public static class ProceduresControllerData
    {
        public static IEnumerable<Procedure> ProceduresWithCategoryAndOccupation()
        {
            var category1 = new ProcedureCategory();

            var category2 = new ProcedureCategory();

            var occupation1 = new Occupation { Name = Global.OccupationConstants.HairStyler };

            var occupation2 = new Occupation { Name = Global.OccupationConstants.Manicurist };

            var procedures = Enumerable.Range(0, 5)
                .Select(p => new Procedure
                {
                    Occupation = occupation1,
                    Category = category1
                });

            for (int i = 0; i < 5; i++)
            {
                procedures = procedures.Append(new Procedure
                {
                    Occupation = occupation2,
                    Category = category2
                });
            }

            return procedures;
        }
    }
}
