using AutoMapper;
using IndigyBackendTestAPI.Application.Model.Dto;
using IndigyBackendTestAPI.Domain.Interfaces.Repositories;
using MediatR;

namespace IndigyBackendTestAPI.Application.Commands.Employee.Handler
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepositories _repo;
        private readonly IMapper _mapper;

        public UpdateEmployeeHandler(IEmployeeRepositories repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repo.GetByIdAsync(request.Id);
            if (employee == null)
            {
                throw new Exception($"Employee with Id {request.Id} not found.");
            }

            employee.UpdateEmployee(
                request.Id,
                request.FirstName,
                request.LastName,
                request.Designation,
                request.Salary,
                request.Comm,
                request.Deptno
            );

            await _repo.UpdateAsync(employee);

            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
