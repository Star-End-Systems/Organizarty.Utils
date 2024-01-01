using FluentValidation;
using Organizarty.Utils.Validations.CustomValidations;

namespace Organizarty.Utils.Tests.Validations.Mock;

public record UserMock(string Password);

public class UserMockValidation : AbstractValidator<UserMock>
{
    public UserMockValidation()
    {
        RuleFor(x => x.Password).Password();
    }
}
