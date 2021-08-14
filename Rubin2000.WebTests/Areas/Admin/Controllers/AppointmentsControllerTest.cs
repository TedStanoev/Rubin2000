using MyTested.AspNetCore.Mvc;
using Rubin2000.Services.ForAppointments.Models;
using Rubin2000.Web.Areas.Admin.Controllers;
using Rubin2000.Web.Areas.Admin.Models.Appointments;
using Xunit;

using static Rubin2000.Global.WebConstants;
using static Rubin2000.Global.WebTestConstants;
using static Rubin2000.WebTests.Areas.Admin.Data.AppointmentsControllerData;
using static Rubin2000.WebTests.Data.AppointmentsControllerData;
using static Rubin2000.WebTests.ModelComparing.ForAppointments;

namespace Rubin2000.WebTests.Areas.Admin.Controllers
{
    public class AppointmentsControllerTest
    {
        [Fact]
        public void ControllerShouldHaveAuthorizeAttributeForAdminsOnly()
            => MyController<AppointmentsController>
                .ShouldHave()
                .Attributes(attributes => attributes
                    .SpecifyingArea(AdminArea)
                    .RestrictingForAuthorizedRequests(AdminRole));

        [Theory]
        [InlineData(AppointmentId)]
        public void InfoShouldReturnViewIfAdminIsLoggedIn(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser(u => u.InRole(AdminRole))
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.Info(id))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AppointmentInfoServiceModel>(
                        m => InfoModelCompare(m)));

        [Theory]
        [InlineData(AppointmentId)]
        public void GetEmployeeDeclineShouldReturnView(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser(u => u.InRole(AdminRole))
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.EmployeeDecline(id))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<DeclineAppointmentViewModel>(
                        m => m.Id == id));

        [Fact]
        public void PostEmployeeDeclineShouldRedirectToEmployeeSchedule()
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser(u => u.InRole(AdminRole))
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.EmployeeDecline(ValidDeclineAppointment()))
                .ShouldReturn()
                .Redirect("/Admin/Schedules/EmployeeSchedule/ScheduleId");
    }
}
