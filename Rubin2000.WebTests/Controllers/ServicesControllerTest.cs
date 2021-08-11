using MyTested.AspNetCore.Mvc;
using Rubin2000.Services.ForProcedures.Models;
using Rubin2000.Web.Controllers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using static Rubin2000.WebTests.Data.ServicesControllerData;

namespace Rubin2000.WebTests.Controllers
{
    public class ServicesControllerTest
    {
        [Fact]
        public void IndexShouldReturnView()
            => MyController<ServicesController>
                .Instance()
                .Calling(c => c.Index())
                .ShouldReturn()
                .View();

        [Fact]
        public void HairShouldReturnViewWithProcedures()
            => MyController<ServicesController>
                .Instance(c => c.WithData(HairProcedures()))
                .Calling(c => c.Hair())
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<IEnumerable<ProcedureListServiceModel>>()
                    .Passing(m => m.Count() == 6));

        [Fact]
        public void NailsShouldReturnViewWithProcedures()
            => MyController<ServicesController>
                .Instance(c => c.WithData(NailProcedures()))
                .Calling(c => c.Nails())
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<IEnumerable<ProcedureListServiceModel>>()
                    .Passing(m => m.Count() == 4));
    }
}
