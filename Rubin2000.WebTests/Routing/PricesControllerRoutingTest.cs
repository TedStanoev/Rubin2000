using MyTested.AspNetCore.Mvc;
using Rubin2000.Web.Controllers;
using Xunit;

namespace Rubin2000.WebTests.Routing
{
    public class PricesControllerRoutingTest
    {
        [Fact]
        public void IndexShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Prices")
                .To<PricesController>(c => c.Index());
    }
}
