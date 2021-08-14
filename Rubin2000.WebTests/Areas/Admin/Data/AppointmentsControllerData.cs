using Rubin2000.Web.Areas.Admin.Models.Appointments;

namespace Rubin2000.WebTests.Areas.Admin.Data
{
    public static class AppointmentsControllerData
    {
        public static DeclineAppointmentViewModel ValidDeclineAppointment()
            => new()
            {
                Id = "AppointmentId",
                Description = "Sorry, but we are closing early today!"
            };
    }
}
