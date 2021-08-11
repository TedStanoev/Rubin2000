using MyTested.AspNetCore.Mvc;
using Rubin2000.Services.ForCategories.Models;
using Rubin2000.Web.Controllers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Rubin2000.WebTests.Controllers
{
    public class PricesControllerTest
    {
        [Fact]
        public void IndexShouldReturnViewWithAllProcedurePrices()
            => MyController<PricesController>
                .Instance(i => i
                .WithData(Data.ProceduresControllerData.ProceduresWithCategoryAndOccupation()))
                .Calling(c => c.Index())
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<IEnumerable<CategoryWithProceduresServiceModel>>()
                    .Passing(p => p.Count() == 2 && p.All(c => c.Procedures.Count() == 5)));
    }
}
