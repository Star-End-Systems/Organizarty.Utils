using FluentValidation;

namespace Organizarty.Utils.Validations.CustomValidations;

public static class PasswordValidation
{
    public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
      => ruleBuilder
         .NotEmpty()
         .MinimumLength(8)
         .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
         .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
         .Matches(@"\d").WithMessage("Password must contain at least one digit.")
         .Matches(@"[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
}
