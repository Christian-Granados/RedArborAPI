using RedArbor.Employees.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedArbor.Employees.DAL.Interfaces
{
    public interface IEmployeeReadingDAL
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
    }
}
