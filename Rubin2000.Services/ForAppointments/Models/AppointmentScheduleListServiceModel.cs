namespace Rubin2000.Services.ForAppointments.Models
{
    public class AppointmentScheduleListServiceModel
    {
        public const int TotalAppointmentsPerPage = 10;

        public int CurrentPage { get; set; }

        public string EmployeeName { get; set; }

        public string AppointmentId { get; set; }

        public string ProcedureName { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string ClientName { get; set; }

        public string ClientId { get; set; }

        public string Status { get; set; }
    }
}
