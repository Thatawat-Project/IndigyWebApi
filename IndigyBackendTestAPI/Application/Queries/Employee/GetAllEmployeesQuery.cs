using IndigyBackendTestAPI.Application.Model.Dto;
using MediatR;

namespace IndigyBackendTestAPI.Application.Queries.Employee
{
    public record GetAllEmployeesQuery(int PageNumber, int PageSize) : IRequest<List<EmployeeDto>>;
}
