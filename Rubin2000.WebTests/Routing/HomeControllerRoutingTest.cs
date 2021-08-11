using MyTested.AspNetCore.Mvc;
using Rubin2000.Web.Controllers;
using Xunit;

namespace Rubin2000.WebTests.Routing
{
    public class HomeControllerRoutingTest
    {
        [Fact]
        public void IndexRouteShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/")
                .To<HomeController>(c => c.Index());

        [Fact]
        public void ErrorRouteShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Home/Error")
                .To<HomeController>(c => c.Error());
    }
}
