using MyTested.AspNetCore.Mvc;
using Rubin2000.Web.Controllers;
using Xunit;

namespace Rubin2000.WebTests.Routing
{
    public class AppointmentsControllerRouting
    {
        [Fact]
        public void MyAppointmentsShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Appointments/MyAppointments")
                .To<AppointmentsController>(c => c.MyAppointments());

        [Theory]
        [InlineData("AppointmentId")]
        public void InfoShouldBeMapped(string id)
            => MyRouting
                .Configuration()
                .ShouldMap("/Appointments/Info/AppointmentId")
                .To<AppointmentsController>(c => c.Info(id));

        [Theory]
        [InlineData("ProcedureId")]
        public void MakeAppointmentShouldBeMapped(string id)
            => MyRouting
                .Configuration()
                .ShouldMap("/Appointments/MakeAppointment/ProcedureId")
                .To<AppointmentsController>(c => c.MakeAppointment(id));

        [Theory]
        [InlineData("AppointmentId")]
        public void ClientDeclineShouldBeMapped(string id)
            => MyRouting
                .Configuration()
                .ShouldMap("/Appointments/ClientDecline/AppointmentId")
                .To<AppointmentsController>(c => c.ClientDecline(id));

        [Theory]
        [InlineData("AppointmentId")]
        public void EditShouldBeMapped(string id)
            => MyRouting
                .Configuration()
                .ShouldMap("/Appointments/Edit/AppointmentId")
                .To<AppointmentsController>(c => c.Edit(id));

        [Theory]
        [InlineData("AppointmentId")]
        public void UserDeleteShouldBeMapped(string id)
            => MyRouting
                .Configuration()
                .ShouldMap("/Appointments/UserDelete/AppointmentId")
                .To<AppointmentsController>(c => c.UserDelete(id));
    }
}
