using AutoMapper;
using RedArbor.Employees.Core.Interfaces;
using RedArbor.Employees.Core.Models;
using RedArbor.Employees.DAL.Interfaces;
using System.Collections.Generic;

namespace RedArbor.Employees.Core
{
    public class EmployeeCore : IEmployeeCore
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeDAL _employeeDAL;

        public EmployeeCore(IMapper mapper, IEmployeeDAL employeeDAL)
        {
            _mapper = mapper;
            _employeeDAL = employeeDAL;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _mapper.Map<List<Employee>>(_employeeDAL.GetEmployees());
        }
        public Employee GetEmployee(int id)
        {
            return _mapper.Map<Employee>(_employeeDAL.GetEmployee(id));
        }
        public Employee AddEmployee(Employee newEmployee)
        {
            return _mapper.Map<Employee>(_employeeDAL.AddEmployee(_mapper.Map<DAL.Entities.Employee>(newEmployee)));
        }
        public void UpdateEmployee(Employee editedEmployee, int id)
        {
            var currentEmployee = _employeeDAL.GetEmployee(id);

            if (currentEmployee == null) throw new KeyNotFoundException();            

            _employeeDAL.UpdateEmployee(_mapper.Map<DAL.Entities.Employee>(currentEmployee), _mapper.Map<DAL.Entities.Employee>(editedEmployee));
        }
        public void DeleteEmployee(int id)
        {
            _employeeDAL.DeleteEmployee(id);
        }
    }
}
