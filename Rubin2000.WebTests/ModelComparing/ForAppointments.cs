using Rubin2000.Services.ForAppointments.Models;

namespace Rubin2000.WebTests.ModelComparing
{
    public static class ForAppointments
    {
        public static bool InfoModelCompare(AppointmentInfoServiceModel model)
            => model.AppointmentId == "AppointmentId"
                        && model.ClientName == "ClientName"
                        && model.Date == "03.02.2100"
                        && model.Time == "18:00"
                        && model.Status == "Pending"
                        && model.Description == "SomeDescription"
                        && model.EmployeeName == "EmployeeName"
                        && model.EmployeeOccupation == "hairstyler"
                        && model.Price == "10 BGN"
                        && model.ProcedureName == "ProcedureName"
                        && model.ProcedureTime == "One Hour"
                        && model.UserFirstName == "UserFirstName"
                        && model.UserLastName == "UserLastName";
    }
}
