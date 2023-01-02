using AutoMapper;
using RedArbor.Employees.API.Models;

namespace RedArbor.Employees.API.Maps
{
    public class EmployeesMapping : Profile
    {
        public EmployeesMapping()
        {
            CreateMap<Employee, Core.Models.Employee>();
            CreateMap<Core.Models.Employee, DAL.Entities.Employee>();

            CreateMap<DAL.Entities.Employee, Core.Models.Employee>();
            CreateMap<Core.Models.Employee, Employee>();
        }
    }
}
