using Dapper;
using RedArbor.Employees.DAL.Data;
using RedArbor.Employees.DAL.Entities;
using RedArbor.Employees.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedArbor.Employees.DAL
{
    public class EmployeeReadingDAL : IEmployeeReadingDAL
    {
        private readonly DapperContext _context;
        public EmployeeReadingDAL(DapperContext context)
        {
            _context = context;
        }
        public List<Employee> GetEmployees()
        {
            using var connection = _context.CreateConnection();
            var employees = connection.Query<Employee>(Querys.Employees.GetEmployees());

            return employees.ToList();
        }
        public Employee GetEmployee(int id)
        {
            using var connection = _context.CreateConnection();
            var employee = connection.QueryFirst<Employee>(Querys.Employees.GetEmployee(id));

            return employee;
        }
    }
}
