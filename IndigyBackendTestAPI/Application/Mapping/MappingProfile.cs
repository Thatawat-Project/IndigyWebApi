using AutoMapper;
using IndigyBackendTestAPI.Application.Model.Dto;
using IndigyBackendTestAPI.Domain.Entities;
namespace IndigyBackendTestAPI.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
