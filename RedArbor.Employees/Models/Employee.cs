using System;

namespace RedArbor.Employees.API.Models
{
    public class Employee
    {
        private int id;
        private int companyId;
        private DateTime? createdOn;
        private DateTime? deletedOn;
        private string email;
        private string fax;
        private string name;
        private DateTime? lastLogin;
        private string password;
        private int portalId;
        private int roleId;
        private int statusId;
        private string telephone;
        private DateTime? updatedOn;
        private string username;

        public int Id { get { return id; } set { id = value; } }
        public int CompanyId { get { return companyId; } set { companyId = value; } }
        public DateTime? CreatedOn { get { return createdOn; } set { createdOn = value; } }
        public DateTime? DeletedOn { get { return deletedOn; } set { deletedOn = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Fax { get { return fax; } set { fax = value; } }
        public string Name { get { return name; } set { name = value; } }
        public DateTime? LastLogin { get { return lastLogin; } set { lastLogin = value; } }
        public string Password { get { return password; } set { password = value; } }
        public int PortalId { get { return portalId; } set { portalId = value; } }
        public int RoleId { get { return roleId; } set { roleId = value; } }
        public int StatusId { get { return statusId; } set { statusId = value; } }
        public string Telephone { get { return telephone; } set { telephone = value; } }
        public DateTime? UpdatedOn { get { return updatedOn; } set { updatedOn = value; } }
        public string Username { get { return username; } set { username = value; } }
    }
}
