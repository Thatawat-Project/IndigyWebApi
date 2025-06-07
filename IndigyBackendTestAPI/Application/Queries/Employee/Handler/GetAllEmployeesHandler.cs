using AutoMapper;
using IndigyBackendTestAPI.Application.Model.Dto;
using IndigyBackendTestAPI.Application.Queries.Employee;
using IndigyBackendTestAPI.Domain.Interfaces.Repositories;
using MediatR;

namespace IndigyBackendTestAPI.Application.Queries.Employee.Handler
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
    {
        private readonly IEmployeeRepositories _repo;
        private readonly IMapper _mapper;

        public GetAllEmployeesHandler(IEmployeeRepositories repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repo.GetAllAsync(request.PageNumber, request.PageSize);
            return _mapper.Map<List<EmployeeDto>>(employees);
        }
    }

}
