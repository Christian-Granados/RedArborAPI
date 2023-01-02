using System;

namespace RedArbor.Employees.Core.Models
{
    public class Employee : EntityAudit
    {
        public int Id;
        public int CompanyId;
        public string Email;
        public string Fax;
        public string Name;
        public DateTime? LastLogin;
        public string Password;
        public int PortalId;
        public int RoleId;
        public int StatusId;
        public string Telephone;
        public string Username;
    }
}
