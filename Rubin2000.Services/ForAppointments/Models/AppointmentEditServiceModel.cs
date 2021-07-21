using Rubin2000.Global;
using Rubin2000.Models;
using Rubin2000.Services.ForEmployees.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Services.ForAppointments.Models
{
    public class AppointmentEditServiceModel
    {
        [Required]
        public string ProcedureName { get; set; }

        [Required]
        public string ProcedureId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(NameDefaultLength, MinimumLength = 2, ErrorMessage = ErrorConstants.InvalidName)]
        public string ClientName { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [MaxLength(DescriptionDefaultLength)]
        public string Description { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        public IEnumerable<EmployeeSelectServiceModel> Employees { get; set; }
    }
}
