using Library.Models;
using FluentValidation;

namespace Library.Validation
{
    public class ValidationCustomer : AbstractValidator<Customer>
    {
        public void CustomerValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().WithMessage("Specify your name");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Specify your surname");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Specify your address");
            RuleFor(x => x.Mobile).NotEmpty().WithMessage("Specify your telephone number");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Specify your mail address");
            RuleFor(x => x.LoginName).NotEmpty().WithMessage("You have to enter Login");
        }
    }
}
