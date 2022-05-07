using FluentValidation;

namespace store.Dto.Authenticate;

public class RegisterDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class ValidateRegisterDto : AbstractValidator<RegisterDto>
{
    public ValidateRegisterDto()
    {
        RuleFor(x => x.Username).NotNull().NotEmpty();
        RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(6);
        RuleFor(x => x.ConfirmPassword).NotNull().NotEmpty().MinimumLength(6);
    }
}