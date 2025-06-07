using System.ComponentModel.DataAnnotations;
using IndigyBackendTestAPI.Application.Model.Dto;
using MediatR;

namespace IndigyBackendTestAPI.Application.Commands.Employee
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public int? Comm { get; set; }
        public int DeptNo { get; set; }
    }
}
