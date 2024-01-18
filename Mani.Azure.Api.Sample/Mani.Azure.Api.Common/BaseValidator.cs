using FluentValidation;
using FluentValidation.Results;

namespace Mani.Azure.Api.Common
{
    public abstract class BaseValidator<T> : AbstractValidator<T>, IBaseValidator<T>
    {
        public new void Validate(T instance)
        {
            var validationResult = base.Validate(instance);
            HandleValidationFailure(validationResult, instance);
        }

        protected virtual void HandleValidationFailure(ValidationResult result, object instance)
        {
            if (!result.IsValid)
            {
                throw new ValidationException(result.ToString(", "));
            }
        }
    }
}
