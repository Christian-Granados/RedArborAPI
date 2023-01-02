using RedArbor.Employees.DAL.Entities;
using System.Collections.Generic;

namespace RedArbor.Employees.DAL.Interfaces
{
    public interface IEmployeeWritingDAL
    {
        Employee AddEmployee(Employee newEmployee);
        void UpdateEmployee(Employee currentEmployee, Employee editedEmployee);
        void DeleteEmployee(int id);
    }
}
