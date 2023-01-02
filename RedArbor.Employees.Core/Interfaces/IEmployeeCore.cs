using RedArbor.Employees.Core.Models;
using System.Collections.Generic;

namespace RedArbor.Employees.Core.Interfaces
{
    public interface IEmployeeCore
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee, int id);
        void DeleteEmployee(int id);
    }
}
