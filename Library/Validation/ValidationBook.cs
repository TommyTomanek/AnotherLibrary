using FluentValidation;
using Library.Models;

namespace Library.Validation
{
    public class ValidationBook : AbstractValidator<Book>
    {
        public void BookValidator()
        {
            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("Specify the author");
        }
    }
}
