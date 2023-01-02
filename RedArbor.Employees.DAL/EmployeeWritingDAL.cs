using Microsoft.EntityFrameworkCore;
using RedArbor.Employees.DAL.Data;
using RedArbor.Employees.DAL.Entities;
using RedArbor.Employees.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedArbor.Employees.DAL
{
    public class EmployeeWritingDAL : IEmployeeWritingDAL
    {
        private static EFContext _context;
        public EmployeeWritingDAL(EFContext context)
        {
            _context = context;
        }
        public Employee AddEmployee(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
            
            return newEmployee;
        }
        public void UpdateEmployee(Employee currentEmployee, Employee editedEmployee)
        {
            _context.Entry<Employee>(currentEmployee).CurrentValues.SetValues(editedEmployee);
            _context.Entry<Employee>(currentEmployee).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.AsNoTracking().FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                throw new KeyNotFoundException();
            } else
            {
                _context.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
