using FluentValidation;
using Mani.Azure.Api.Common.Validators;
using Mani.Azure.Api.Models;

namespace Mani.Azure.Api.Common
{
    public class EmployeeValidator : BaseValidator<Employee>, IEmployeeValidator
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmployeeName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Missing Emloyee Name")
                .Must(name => name?.Length <= 50)
                .WithMessage("Emp Name maxLength(50 char)");

            RuleFor(x => x.Address)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Missing Address")
                .Must(name => name?.Length <= 50)
                .WithMessage("Address maxLength(50 char)");

            RuleFor(x => x.State)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Missing State");

            RuleFor(x => x.DateOfBirth)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Missing Date of Birth");
        }
    }
}
