using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rubin2000.Models;

using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Web.Models.Appointments
{
    public class AppointmentInputViewModel
    {
        public string ProcedureName { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        [MaxLength(DescriptionDefaultLength)]
        public string Description { get; set; }

        public string EmployeeId { get; set; }

        public List<SelectListItem> Employees { get; set; }
    }
}
