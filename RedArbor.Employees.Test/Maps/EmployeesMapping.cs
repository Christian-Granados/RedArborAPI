using AutoMapper;

namespace RedArbor.Employees.Test.Maps
{
    public class EmployeesMapping : Profile
    {
        public EmployeesMapping()
        {
            CreateMap<Core.Models.Employee, DAL.Entities.Employee>();
            CreateMap<DAL.Entities.Employee, Core.Models.Employee>();
        }
    }
}
