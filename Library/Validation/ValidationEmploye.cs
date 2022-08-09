using FluentValidation;
using Library.Models;

namespace Library.Validation
{
    public class ValidationEmploye : AbstractValidator<Employe>
    {
        public ValidationEmploye()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Specify your name");
            RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage("Specify your surname");
            RuleFor(x => x.Address).NotEmpty().NotNull().WithMessage("Specify your address");
            RuleFor(x => x.Mobile).NotEmpty().NotNull().WithMessage("Specify your telephone number");
            RuleFor(x => x.Mail).NotEmpty().NotNull().WithMessage("Specify your mail address");
            RuleFor(x => x.SuperiorId).NotEmpty().NotNull().WithMessage("Who is your superior");
            RuleFor(x => x.Inferiors).NotEmpty().NotNull().WithMessage("Specify your inferiors");
        }
    }
}
