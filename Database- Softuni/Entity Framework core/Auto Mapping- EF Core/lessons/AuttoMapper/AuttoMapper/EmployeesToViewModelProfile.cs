namespace AuttoMapper
{
    using AutoMapper;
    using AuttoMapper.Models;
    using AuttoMapper.ViewModels;

    public class EmployeesToViewModelProfile:Profile
    {
        public EmployeesToViewModelProfile()
        {
            this.CreateMap<Employee, EmployeeDepartment>()
             .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name))
             .ReverseMap();
        }
    }
}
