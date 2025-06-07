using System.Globalization;
using IndigyBackendTestAPI.Application.Commands.Employee;
using IndigyBackendTestAPI.Application.Model.View;
using IndigyBackendTestAPI.Application.Queries.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IndigyBackendTestAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            var employee = await _mediator.Send(new GetAllEmployeesQuery(pageNumber, pageSize));

            var data = employee.Select(e => new EmployeeView
            {
                EmpNo = e.EmpNo,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Designation = e.Designation,
                HireDate = e.HireDate.ToString("dd-MMM-yy", CultureInfo.InvariantCulture),
                Salary = e.Salary,
                Comm = e.Comm,
                DeptNo = e.DeptNo,
                IsDelete = e.IsDelete,
                CreateDate = e.CreateDate,
                UpdateDate = e.UpdateDate
            });

            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));

            if (employee == null)
                return NotFound();

            var result = new EmployeeView
            {
                EmpNo = employee.EmpNo,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Designation = employee.Designation,
                HireDate = employee.HireDate.ToString("dd-MMM-yy", CultureInfo.InvariantCulture),
                Salary = employee.Salary,
                Comm = employee.Comm,
                DeptNo = employee.DeptNo,
                IsDelete = employee.IsDelete,
                CreateDate = employee.CreateDate,
                UpdateDate = employee.UpdateDate
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var success = await _mediator.Send(new DeleteEmployeeCommand { Id = id });

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
