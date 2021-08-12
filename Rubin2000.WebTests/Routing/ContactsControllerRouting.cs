using MyTested.AspNetCore.Mvc;
using Rubin2000.Web.Controllers;
using Xunit;

namespace Rubin2000.WebTests.Routing
{
    public class ContactsControllerRouting
    {
        [Fact]
        public void IndexShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Contacts")
                .To<ContactsController>(c => c.Index());
    }
}
