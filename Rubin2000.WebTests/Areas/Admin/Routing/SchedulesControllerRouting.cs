using MyTested.AspNetCore.Mvc;
using Rubin2000.Web.Areas.Admin.Controllers;
using Xunit;

using static Rubin2000.Global.WebTestConstants;

namespace Rubin2000.WebTests.Areas.Admin.Routing
{
    public class SchedulesControllerRouting
    {
        [Fact]
        public void IndexShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Admin/Schedules")
                .To<SchedulesController>(c => c.Index());

        [Theory]
        [InlineData(ScheduleId)]
        public void EmployeeScheduleShouldBeMapped(string id)
            => MyRouting
                .Configuration()
                .ShouldMap($"/Admin/Schedules/EmployeeSchedule/{id}")
                .To<SchedulesController>(c => c.EmployeeSchedule(id));

        [Theory]
        [InlineData(ScheduleId, 1)]
        public void AllShouldBeMapped(string id, int count)
            => MyRouting
                .Configuration()
                .ShouldMap($"/Admin/Schedules/All/{id}?currentPage={count}")
                .To<SchedulesController>(c => c.All(id, count));

        [Theory]
        [InlineData(AppointmentId)]
        public void ApproveShouldBeMapped(string id)
            => MyRouting
                .Configuration()
                .ShouldMap($"/Admin/Schedules/Approve/{id}")
                .To<SchedulesController>(c => c.Approve(id));

        [Theory]
        [InlineData(AppointmentId)]
        public void DeleteShouldBeMapped(string id)
            => MyRouting
                .Configuration()
                .ShouldMap($"/Admin/Schedules/Delete/{id}")
                .To<SchedulesController>(c => c.Delete(id));
    }
}
