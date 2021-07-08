using Rubin2000.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForEmployees
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();

        IEnumerable<Employee> GetEmployeesByProcedure(string procedureName);
    }
}
