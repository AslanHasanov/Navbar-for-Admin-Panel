using DemoApplication.ViewModels.Admin.Navbar;
using FluentValidation;


namespace DemoApplication.Validators.Admin.Navbar.Add
{
    public class NavbarAddValidator : AbstractValidator<AddViewModel>
    {
        public NavbarAddValidator()
        {
            RuleFor(avm => avm.Title)
                .NotNull()
                .WithMessage("Title is required")
                .NotEmpty()
                .WithMessage("Title is required")
                .MinimumLength(5)
                .WithMessage("Minimum length must be 5")
                .MaximumLength(25)
                .WithMessage("Maximum length must be 25");


            RuleFor(avm => avm.URL)
           .NotNull()
           .WithMessage("URL is required")
           .NotEmpty()
           .WithMessage("URL is required")
           .MinimumLength(5)
           .WithMessage("Minimum length must be 5")
           .MaximumLength(50)
           .WithMessage("Maximum length must be 50");
        }
    }
}

