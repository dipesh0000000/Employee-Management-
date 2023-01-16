using AutoMapper;
using EmployeeAPI.Entities;
using EmployeeAPI.Model;

namespace EmployeeAPI.MappingProfile
{
    public class QualificationProfile : Profile
    {
        public QualificationProfile()
        {
            CreateMap<Qualification, QualificationModel>()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
