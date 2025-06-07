using IndigyBackendTestAPI.Domain.Interfaces.Repositories;
using IndigyBackendTestAPI.Infrastructure.Db;
using MediatR;

namespace IndigyBackendTestAPI.Application.Commands.Employee.Handler
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepositories _repo;
        public DeleteEmployeeHandler(IEmployeeRepositories repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.Id);
            return true;
        }
    }
}
