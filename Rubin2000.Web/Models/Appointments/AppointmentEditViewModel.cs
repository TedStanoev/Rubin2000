using System.ComponentModel.DataAnnotations;

using static Rubin2000.Models.DataConstants.EFAttributeConstants;
namespace Rubin2000.Web.Models.Appointments
{
    public class AppointmentEditViewModel
    {
        public string ProcedureName { get; init; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [MaxLength(DescriptionDefaultLength)]
        public string Description { get; set; }


    }
}
