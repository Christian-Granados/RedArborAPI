using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedArbor.Employees.DAL.Querys
{
    internal static class Employees
    {
        private const string Select = "SELECT * FROM Employees";
        public static string GetEmployees()
        {
            return Select;
        }
        public static string GetEmployee(int id)
        {
            return $"{Select} WHERE Id = '{id}'";
        }
    }
}
