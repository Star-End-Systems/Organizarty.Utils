using FluentValidation;
using Organizarty.Domain.Exceptions;

namespace Organizarty.Utils.Validations.Extensions;

public static class ValidatorExtension
{
    public static void Check<T>(this IValidator<T> validator, T value, string message)
    {
        var result = validator.Validate(value);

        if (result.IsValid)
        {
            return;
        }

        var errors = result
          .Errors
          .Select(e => new ValidationError(e.PropertyName, e.ErrorMessage))
          .ToList();

        throw new ValidationFailException(message, errors);
    }
}
