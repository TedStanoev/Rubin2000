using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rubin2000.Models;
using static Rubin2000.Models.DataConstants.EFAttributeConstants;

namespace Rubin2000.Web.Models.Appointments
{
    public class AppointmentInputViewModel
    {
        [Required]
        public string ProcedureName { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [MaxLength(DescriptionDefaultLength)]
        public string Description { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
