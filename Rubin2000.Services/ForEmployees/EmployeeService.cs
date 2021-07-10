using Microsoft.EntityFrameworkCore;
using Rubin2000.Data;
using Rubin2000.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rubin2000.Services.ForEmployees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Rubin2000DbContext data;

        public EmployeeService(Rubin2000DbContext data)
        {
            this.data = data;
        }

        public IEnumerable<Employee> GetEmployees()
            => this.data.Employees
                .ToList();

        public IEnumerable<Employee> GetEmployeesWithOccupation()
            => this.data.Employees
                .Include(e => e.Occupation)
                .ToList();

        public IEnumerable<Employee> GetEmployeesByProcedure(string procedureName)
        {
            var occupation = this.data.Occupations.FirstOrDefault(o => o.Procedures.Any(p => p.Name == procedureName));

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
    }
}
