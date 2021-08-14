using MyTested.AspNetCore.Mvc;
using Rubin2000.Web.Areas.Admin.Controllers;
using Xunit;

using static Rubin2000.Global.WebTestConstants;

namespace Rubin2000.WebTests.Areas.Admin.Routing
{
    public class AppointmentsControllerRouting
    {
        [Theory]
        [InlineData(AppointmentId)]
        public void InfoShouldBeMapped(string id)
            => MyRouting
                .Configuration()
                .ShouldMap($"/Admin/Appointments/Info/{id}")
                .To<AppointmentsController>(c => c.Info(id));

        [Theory]
        [InlineData(AppointmentId)]
        public void EmployeeDeclineShouldBeMapped(string id)
            => MyRouting
                .Configuration()
                .ShouldMap($"/Admin/Appointments/EmployeeDecline/{id}")
                .To<AppointmentsController>(c => c.EmployeeDecline(id));
    }
}
