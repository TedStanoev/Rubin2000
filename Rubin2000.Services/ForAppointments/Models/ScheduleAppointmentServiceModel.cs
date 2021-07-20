namespace Rubin2000.Services.ForAppointments.Models
{
    public class ScheduleAppointmentServiceModel
    {
        public string AppointmentId { get; set; }

        public string ProcedureName { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string ClientName { get; set; }

        public string ClientId { get; set; }

        public string Status { get; set; }
    }
}
