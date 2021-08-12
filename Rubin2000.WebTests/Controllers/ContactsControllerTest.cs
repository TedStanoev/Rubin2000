using MyTested.AspNetCore.Mvc;
using Rubin2000.Web.Controllers;
using Xunit;

namespace Rubin2000.WebTests.Controllers
{
    public class ContactsControllerTest
    {
        [Fact]
        public void IndexShouldReturnView()
            => MyController<ContactsController>
                .Instance()
                .Calling(c => c.Index())
                .ShouldReturn()
                .View();
    }
}
