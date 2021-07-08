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

        public IEnumerable<Employee> GetEmployeesByProcedure(string procedureId)
        {
            var occupation = this.data.Occupations.FirstOrDefault(o => o.Procedures.Any(p => p.Id == procedureId));

            return this.GetEmployees()
                    .Where(e => e.Occupation == occupation)
                    .ToList();
        }
    }
}
