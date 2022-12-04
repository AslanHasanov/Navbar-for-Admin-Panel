using DemoApplication.ViewModels.Admin.Navbar;
using FluentValidation;


namespace DemoApplication.Validators.Admin.Navbar.Update
{
    public class NavbarUpdateValidator : AbstractValidator<UpdateViewModel>
    {
        public NavbarUpdateValidator()
        {
            RuleFor(uvm => uvm.Title)
                .NotNull()
                .WithMessage("Title is required")
                .NotEmpty()
                .WithMessage("Title is required")
                .MinimumLength(5)
                .WithMessage("Minimum length must be 5")
                .MaximumLength(25)
                .WithMessage("Maximum length must be 25");


            RuleFor(uvm => uvm.URL)
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

