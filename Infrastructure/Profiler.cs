using AutoMapper;
using NewFeatureApplication.Models;
using NewFeatureApplication.ViewModels;

namespace NewFeatureApplication.Infrastructure {
    public class Profiler : Profile {
        public Profiler () {
            CreateMap<Employee, EmployeeVm> ().ReverseMap ();
            CreateMap<CreateEmployee, Employee> ().ReverseMap ();
            CreateMap<Department, DepartmentVm> ().
            ForMember (x => x.Label, opt => opt.MapFrom (x => x.Name)).
            ForMember (x => x.Value, opt => opt.MapFrom (x => x.DepartmentId));

            CreateMap<CreateDepartment, Department> ().ReverseMap ();
        }
    }
}