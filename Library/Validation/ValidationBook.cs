using FluentValidation;
using Library.Models;

namespace Library.Validation
{
    public class ValidationBook : AbstractValidator<Book>
    {
        public ValidationBook()
        {
            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("Specify the author");
        }
    }
}
