using AutoMapper;
using EmployeeAPI.Entities;
using EmployeeAPI.Model;

namespace EmployeeAPI.MappingProfile
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeModel>()
             .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
