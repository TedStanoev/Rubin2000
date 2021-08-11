using MyTested.AspNetCore.Mvc;
using Rubin2000.Web.Controllers;
using Rubin2000.Web.Models;
using Xunit;

namespace Rubin2000.WebTests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnView()
            => MyController<HomeController>
                .Instance()
                .Calling(c => c.Index())
                .ShouldReturn()
                .View();

        [Fact]
        public void ErrorShouldReturnErrorView()
            => MyController<HomeController>
                .Instance()
                .Calling(c => c.Error())
                .ShouldReturn()
                .View(v => v.WithModelOfType(typeof(ErrorViewModel)));
    }
}
