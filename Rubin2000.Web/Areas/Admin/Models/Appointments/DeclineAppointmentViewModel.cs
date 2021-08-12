using System.ComponentModel.DataAnnotations;

namespace Rubin2000.Web.Areas.Admin.Models.Appointments
{
    public class DeclineAppointmentViewModel
    {
        public string Id { get; set; }

        [StringLength(200, ErrorMessage = "The description must be less than 200 characters.")]
        public string Description { get; set; }
    }
}
