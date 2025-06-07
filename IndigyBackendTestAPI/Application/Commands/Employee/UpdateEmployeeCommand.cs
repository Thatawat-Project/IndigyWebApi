using MediatR;
using IndigyBackendTestAPI.Application.Model.Dto;
using System.ComponentModel.DataAnnotations;

public class UpdateEmployeeCommand : IRequest<EmployeeDto>
{
    [Required(ErrorMessage = "Id is required.")]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Designation { get; set; }
    public int Deptno { get; set; }
    public decimal Salary { get; set; }
    public int Comm {  get; set; }
}
