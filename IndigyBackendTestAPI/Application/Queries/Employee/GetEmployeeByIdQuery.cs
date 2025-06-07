using IndigyBackendTestAPI.Application.Model.Dto;
using MediatR;

namespace IndigyBackendTestAPI.Application.Queries.Employee
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
        public GetEmployeeByIdQuery(int id) => Id = id;
    }
}
