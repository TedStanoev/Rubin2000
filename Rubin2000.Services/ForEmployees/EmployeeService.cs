using Microsoft.EntityFrameworkCore;
using Rubin2000.Data;
using Rubin2000.Models;
using Rubin2000.Services.ForOccupations;
using Rubin2000.Services.ForSchedules;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Employee> GetEmployees()
            => this.data.Employees
                .ToList();

        public IEnumerable<Employee> GetEmployeesWithOccupation()
            => this.data.Employees
                .Include(e => e.Occupation)
                .ToList();

        public IEnumerable<Employee> GetEmployeesByProcedure(string procedureId)
        {
            var occupation = this.data.Occupations
                .FirstOrDefault(o => o.Procedures.Any(p => p.Id == procedureId));

            return this.GetEmployees()
                    .Where(e => e.Occupation == occupation)
                    .ToList();
        }

        public Employee GetEmployeeById(string id)
            => this.data.Employees
                .Where(e => e.Id == id)
                .FirstOrDefault();

        public Employee GetEmployeeByScheduleId(string scheduleId)
            => this.data.Schedules
                .Where(s => s.Id == scheduleId)
                .Select(s => s.Employee)
                .FirstOrDefault();

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
    }
}
