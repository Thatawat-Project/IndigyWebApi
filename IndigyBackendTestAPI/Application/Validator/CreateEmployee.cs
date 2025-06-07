using FluentValidation;
using IndigyBackendTestAPI.Application.Commands.Employee;

namespace IndigyBackendTestAPI.Application.Validator
{
    public class CreateEmployee : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployee()
        {
            RuleFor(x => x.FirstName)
              .NotEmpty().WithMessage("First name is required.")
              .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100);

            RuleFor(x => x.Designation)
                .NotEmpty().WithMessage("Designation is required.")
                .MaximumLength(50);

        }
    }
}
