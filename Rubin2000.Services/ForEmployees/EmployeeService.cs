using Rubin2000.Data;
using Rubin2000.Services.ForEmployees.Models;
using Rubin2000.Services.ForOccupations;
using System;
using System.Collections.Generic;
using System.Linq;

using static Rubin2000.Global.FormatConstants;

namespace Rubin2000.Services.ForEmployees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Rubin2000DbContext data;
        private readonly IOccupationService occupationService;

        public EmployeeService(Rubin2000DbContext data, IOccupationService occupationService)
        {
            this.data = data;
            this.occupationService = occupationService;
        }

        public IEnumerable<EmployeeSelectServiceModel> GetEmployeesForSelect(string procedureId)
        {
            var procedure = this.data.Procedures
                .Where(p => p.Id == procedureId)
                .Select(p => new
                {
                    p.Occupation.Employees
                })
                .FirstOrDefault();

            return procedure.Employees
                    .Select(e => new EmployeeSelectServiceModel
                    {
                        Id = e.Id,
                        Name = e.Name
                    })
                    .ToList();
        }

        public bool EmployeeExists(string id)
            => this.data.Employees
                .Any(e => e.Id == id);

        public bool EmployeeCanDoProcedure(string employeeId, string procedureId)
        {
            var employeeOccupation = occupationService.GetEmployeeOccupation(employeeId);
            var procedureOccupation = occupationService.GetProcedureOccupation(procedureId);

            if (employeeOccupation == procedureOccupation
                && employeeOccupation != null
                && procedureOccupation != null)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<EmployeeServiceModel> GetAllEmployeesWithSchedule()
            => this.data.Schedules
                .Select(s => new EmployeeServiceModel
                {
                    Name = s.Employee.Name,
                    ScheduleId = s.Id,
                    StartsAt = s.StartsAt.ToString(TimeViewFormat),
                    EndsAt = s.EndsAt.ToString(TimeViewFormat)
                })
                .OrderBy(s => s.Name)
                .ToList();

        public string GetEmployeeNameByScheduleId(string scheduleId)
            => this.data.Employees
                .Where(e => e.ScheduleId == scheduleId)
                .FirstOrDefault()
                .Name;
    }
}
