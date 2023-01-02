using RedArbor.Employees.DAL.Entities;
using RedArbor.Employees.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedArbor.Employees.DAL
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private IEmployeeReadingDAL _employeeReadingDAL;
        private IEmployeeWritingDAL _employeeWritingDAL;

        public EmployeeDAL(IEmployeeReadingDAL employeeReadingDAL, IEmployeeWritingDAL employeeWritingDAL)
        {
            _employeeReadingDAL = employeeReadingDAL;
            _employeeWritingDAL = employeeWritingDAL;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeReadingDAL.GetEmployees();
        }
        public Employee GetEmployee(int id)
        {
            return _employeeReadingDAL.GetEmployee(id);
        }
        public Employee AddEmployee(Employee newEmployee)
        {
            _employeeWritingDAL.AddEmployee(newEmployee);
            
            return newEmployee;
        }
        public void UpdateEmployee(Employee currentEmployee, Employee editedEmployee)
        {
            _employeeWritingDAL.UpdateEmployee(currentEmployee, editedEmployee);
        }
        public void DeleteEmployee(int id)
        {
            _employeeWritingDAL.DeleteEmployee(id);
        }
    }
}
