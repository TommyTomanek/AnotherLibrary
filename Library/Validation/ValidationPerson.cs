using FluentValidation;
using Library.Models;

namespace Library.Validation
{
    public class ValidationPerson : AbstractValidator<Person>
    {
        public void PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Specify your name");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Specify your surname");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Specify your address");
            RuleFor(x => x.Mobile).NotEmpty().WithMessage("Specify your telephone number");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Specify your mail address");
            RuleFor(x => new { x.Mail, x.Mobile }).Must(m => ContainsMobileOrMail(m.Mail, m.Mobile));
        }
        public bool ContainsMobileOrMail(string Mail, string Mobile)
        {
            if (Mail == null && Mobile == null)
            {
                return false;
            }
            else
                return true;
        }
    }
}
