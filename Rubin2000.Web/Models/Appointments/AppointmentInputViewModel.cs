using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Rubin2000.Models;
using Rubin2000.Global;

using static Rubin2000.Models.DataConstants.EFAttributeConstants;
using static Rubin2000.Global.ErrorConstants;

using Rubin2000.Services.ForEmployees.Models;

namespace Rubin2000.Web.Models.Appointments
{
    public class AppointmentInputViewModel
    {
        [Required]
        public string ProcedureName { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(NameDefaultLength, MinimumLength = 2, ErrorMessage = InvalidName)]
        public string ClientName { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [MaxLength(DescriptionDefaultLength, ErrorMessage = InvalidDescription)]
        public string Description { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        public List<EmployeeSelectServiceModel> Employees { get; set; }
    }
}
