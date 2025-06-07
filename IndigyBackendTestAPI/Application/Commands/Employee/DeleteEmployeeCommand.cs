using MediatR;

namespace IndigyBackendTestAPI.Application.Commands.Employee
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
