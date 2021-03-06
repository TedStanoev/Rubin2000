using MyTested.AspNetCore.Mvc;
using Rubin2000.Services.ForAppointments.Models;
using Rubin2000.Web.Controllers;
using Rubin2000.Web.Models.Appointments;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using static Rubin2000.Global.WebTestConstants;
using static Rubin2000.WebTests.Data.AppointmentsControllerData;
using static Rubin2000.WebTests.ModelComparing.ForAppointments;

namespace Rubin2000.WebTests.Controllers
{
    public class AppointmentsControllerTest
    {
        [Fact]
        public void MyAppointmentsShouldReturnViewWithUserUndeletedAppointments()
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(UserAppointments()))
                .Calling(c => c.MyAppointments())
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<IEnumerable<UserAppointmentServiceModel>>(
                        m => m.Count() == 5));

        [Theory]
        [InlineData(AppointmentId)]
        public void InfoShouldReturnTheViewOfTheGivenAppointment(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.Info(id))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AppointmentInfoServiceModel>(
                        m => InfoModelCompare(m)));

        [Theory]
        [InlineData(AppointmentId)]
        public void InfoShouldReturnUnauthorizedWhenTheUserIsntAnAdminOrIsTheCreatorOfAppointment(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser(u => u.WithIdentifier("WrongUser"))
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.Info(id))
                .ShouldReturn()
                .Unauthorized();

        [Theory]
        [InlineData(ProcedureId)]
        public void GetMakeAppointmentShouldReturnView(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(ProcedureWithOccupationAndEmployee()))
                .Calling(c => c.MakeAppointment(id))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AppointmentInputViewModel>(
                        m => m.ProcedureName == "ProcedureName"
                        && m.Employees.Count == 1));

        [Theory]
        [InlineData(ProcedureId)]
        public void PostMakeAppointmentWithValidInputShouldRedirectToMyAppointments(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(ProcedureWithOccupationAndEmployee()))
                .Calling(c => c.MakeAppointment(ValidInputForAppointment(), id))
                .ShouldReturn()
                .Redirect("/Appointments/MyAppointments");

        [Theory]
        [InlineData(ProcedureId)]
        public void PostMakeAppointmentWithInvalidInputShouldReturnViewToMakeAppointment(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(ProcedureWithOccupationAndEmployee()))
                .Calling(c => c.MakeAppointment(InvalidInputForAppointment(), id))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AppointmentInputViewModel>());

        [Theory]
        [InlineData(AppointmentId)]
        public void GetClientDeclineWithValidDataShouldReturnView(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.ClientDecline(id))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<DeclineAppointmentViewModel>(
                        m => m.Id == id));

        [Theory]
        [InlineData("SomeInvalidId")]
        public void GetClientDeclineWithInvalidAppointmentIdShouldReturnNotFound(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.ClientDecline(id))
                .ShouldReturn()
                .NotFound();

        [Theory]
        [InlineData(AppointmentId)]
        public void GetClientDeclineWithInvalidOwnerShouldReturnUnauthorized(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser(u => u.WithIdentifier("WrongUser"))
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.ClientDecline(id))
                .ShouldReturn()
                .Unauthorized();

        [Fact]
        public void PostClientDeclineWithCorrectDataShouldRedirectToMyAppointments()
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.ClientDecline(ValidDecline()))
                .ShouldReturn()
                .Redirect("/Appointments/MyAppointments");

        [Theory]
        [InlineData(AppointmentId)]
        public void GetEditWithValidDataShouldReturnView(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.Edit(id))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AppointmentEditServiceModel>());

        [Theory]
        [InlineData(AppointmentId)]
        public void PostEditWithValidInputShouldRedirectToMyAppointments(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.Edit(ValidEditAppointment(), id))
                .ShouldReturn()
                .Redirect("/Appointments/MyAppointments");

        [Theory]
        [InlineData(AppointmentId)]
        public void PostEditWithInvalidInputShouldReturnView(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.Edit(InvalidEditAppointment(), id))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AppointmentEditServiceModel>(
                        m => m.Employees.Count() == 1));

        [Theory]
        [InlineData(AppointmentId)]
        public void UserDeleteWithOwnerUserShouldRedirectToMyAppointments(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser()
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.UserDelete(id))
                .ShouldReturn()
                .Redirect("/Appointments/MyAppointments");

        [Theory]
        [InlineData(AppointmentId)]
        public void UserDeleteWithUserWhoIsNotOwnerShouldReturnUnauthorized(string id)
            => MyController<AppointmentsController>
                .Instance(i => i.WithUser(u => u.WithIdentifier("Invalid"))
                    .AndAlso()
                    .WithData(Appointment()))
                .Calling(c => c.UserDelete(id))
                .ShouldReturn()
                .Unauthorized();
    }
}
