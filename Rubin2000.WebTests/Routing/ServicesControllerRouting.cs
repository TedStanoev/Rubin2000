using MyTested.AspNetCore.Mvc;
using Rubin2000.Web.Controllers;
using Xunit;

namespace Rubin2000.WebTests.Routing
{
    public class ServicesControllerRouting
    {
        [Fact]
        public void IndexShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Services")
                .To<ServicesController>(c => c.Index());

        [Fact]
        public void HairShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Services/Hair")
                .To<ServicesController>(c => c.Hair());

        [Fact]
        public void NailsShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Services/Nails")
                .To<ServicesController>(c => c.Nails());
    }
}
