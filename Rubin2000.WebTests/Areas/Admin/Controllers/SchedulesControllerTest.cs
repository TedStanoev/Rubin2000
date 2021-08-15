using MyTested.AspNetCore.Mvc;
using Rubin2000.Services.ForAppointments.Models;
using Rubin2000.Services.ForEmployees.Models;
using Rubin2000.Services.ForSchedules.Models;
using Rubin2000.Web.Areas.Admin.Controllers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using static Rubin2000.Global.WebConstants;
using static Rubin2000.Global.WebTestConstants;
using static Rubin2000.WebTests.Areas.Admin.Data.SchedulesControllerData;

namespace Rubin2000.WebTests.Areas.Admin.Controllers
{
    public class SchedulesControllerTest
    {
        [Fact]
        public void ControllerShouldHaveAuthorizeAttributeForAdminsOnly()
            => MyController<SchedulesController>
                .ShouldHave()
                .Attributes(attributes => attributes
                    .SpecifyingArea(AdminArea)
                    .RestrictingForAuthorizedRequests(AdminRole));

        [Fact]
        public void IndexShouldReturnView()
            => MyController<SchedulesController>
                .Instance(i => i.WithUser(u => u.InRole(AdminRole))
                    .AndAlso()
                    .WithData(EmployeesWithSchedules()))
                .Calling(c => c.Index())
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<IEnumerable<EmployeeServiceModel>>(
                        m => m.Count() == 2));

        [Theory]
        [InlineData(ScheduleId)]
        public void EmployeeScheduleShouldReturnView(string id)
            => MyController<SchedulesController>
                .Instance(i => i.WithUser(u => u.InRole(AdminRole))
                    .AndAlso()
                    .WithData(Schedule()))
                .Calling(c => c.EmployeeSchedule(id))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<IEnumerable<EmployeeScheduleAppointmentServiceModel>>(
                        m => m.Count() == 2));

        [Theory]
        [InlineData(ScheduleId)]
        public void AllShouldReturnView(string id)
            => MyController<SchedulesController>
                .Instance(i => i.WithUser(u => u.InRole(AdminRole))
                    .AndAlso()
                    .WithData(Schedule()))
                .Calling(c => c.All(id, 1))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<IEnumerable<AppointmentScheduleServiceModel>>(
                        m => m.Count() == 2));

        [Theory]
        [InlineData(AppointmentId)]
        public void ApproveShouldRedirectToEmployeeSchedule(string id)
            => MyController<SchedulesController>
                .Instance(i => i.WithUser(u => u.InRole(AdminRole))
                    .AndAlso()
                    .WithData(ApproveAppointment()))
                .Calling(c => c.Approve(id))
                .ShouldReturn()
                .Redirect($"/Admin/Schedules/EmployeeSchedule/{ScheduleId}");

        [Theory]
        [InlineData("InvalidId")]
        public void ApproveWithInvalidAppointmentIdShouldReturnNotFound(string id)
            => MyController<SchedulesController>
                .Instance(i => i.WithUser(u => u.InRole(AdminRole))
                    .AndAlso()
                    .WithData(ApproveAppointment()))
                .Calling(c => c.Approve(id))
                .ShouldReturn()
                .NotFound();

        [Theory]
        [InlineData(AppointmentId)]
        public void DeleteShouldRedirectToAll(string id)
            => MyController<SchedulesController>
                .Instance(i => i.WithUser(u => u.InRole(AdminRole))
                    .AndAlso()
                    .WithData(DeleteAppointment()))
                .Calling(c => c.Delete(id))
                .ShouldReturn()
                .Redirect($"/Admin/Schedules/All/{ScheduleId}");

        [Theory]
        [InlineData("InvalidId")]
        public void DeleteWithInvalidAppointmentIdShouldReturnNotFound(string id)
            => MyController<SchedulesController>
                .Instance(i => i.WithUser(u => u.InRole(AdminRole))
                    .AndAlso()
                    .WithData(DeleteAppointment()))
                .Calling(c => c.Delete(id))
                .ShouldReturn()
                .NotFound();
    }
}
