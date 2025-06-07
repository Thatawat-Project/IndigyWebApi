using AutoMapper;
using IndigyBackendTestAPI.Application.Model.Dto;
using IndigyBackendTestAPI.Domain.Interfaces.Repositories;
using MediatR;

namespace IndigyBackendTestAPI.Application.Queries.Employee.Handler
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IEmployeeRepositories _repo;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IEmployeeRepositories repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _repo.GetByIdAsync(request.Id);

            if (employee == null)
                throw new Exception($"Employee with Id {request.Id} not found.");

            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
