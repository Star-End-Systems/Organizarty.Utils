using Organizarty.Domain.Exceptions;
using Organizarty.Utils.Tests.Validations.Mock;
using Organizarty.Utils.Validations.Extensions;

namespace Organizarty.Utils.Tests.Validations.Tests;

public class ValidatePasswordTest
{
    [Fact]
    public void Success_ValidPassword()
    {
        var p = new UserMock("Test3!23");

        new UserMockValidation().Check(p, "Validation fail");
    }

    [Fact]
    public void Fail_WithoutSpecialCharacters()
    {
        var p = new UserMock("Test32311");

        var ex = Assert.Throws<ValidationFailException>(() =>
        {
            new UserMockValidation().Check(p, "Validation fail");
        });

        Assert.Single(ex.Errors);

        Assert.Equal("Password must contain at least one special character.", ex.Errors[0].Message);
    }

    [Fact]
    public void Fail_WithoutNumber()
    {
        var p = new UserMock("Testadasdasd!a");

        var ex = Assert.Throws<ValidationFailException>(() =>
        {
            new UserMockValidation().Check(p, "Validation fail");
        });

        Assert.Single(ex.Errors);

        Assert.Equal("Password must contain at least one digit.", ex.Errors[0].Message);
    }

    [Fact]
    public void Fail_WithoutUpperCase()
    {
        var p = new UserMock("testadasd1asd!a");

        var ex = Assert.Throws<ValidationFailException>(() =>
        {
            new UserMockValidation().Check(p, "Validation fail");
        });

        Assert.Single(ex.Errors);

        Assert.Equal("Password must contain at least one uppercase letter.", ex.Errors[0].Message);
    }
}
