using AutoMapper;
using IndigyBackendTestAPI.Application.Model.Dto;
using IndigyBackendTestAPI.Domain.Entities;
using IndigyBackendTestAPI.Domain.Interfaces.Repositories;
using MediatR;

namespace IndigyBackendTestAPI.Application.Commands.Employee.Handler
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepositories _repo;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IEmployeeRepositories repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var gnerateNextEmpNo = _repo.GenerateNextEmpNo();

            var data = new Domain.Entities.Employee(
                gnerateNextEmpNo,
                request.FirstName,
                request.LastName,
                request.Designation,
                request.HireDate,
                request.Salary,
                request.Comm,
                request.DeptNo,
                false,
                DateTime.Now,
                null
            );


            await _repo.AddAsync(data);
            return _mapper.Map<EmployeeDto>(data);
        }
    }
}
