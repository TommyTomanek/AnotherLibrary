using Library.Models;
using FluentValidation;

namespace Library.Validation
{
    public class Validation : AbstractValidator<Customer>
    {
        public void CustomerValidation()
        {
            RuleFor(customer => customer.Name).NotNull();
            RuleFor(customer=> customer.Surname).NotNull();
            RuleFor(customer => customer.Mobile).NotNull();
            RuleFor(customer => customer.Address).NotNull();
            RuleFor(customer => customer.LoginName).NotNull();
            RuleFor(customer => customer.Mail).NotNull();
        }
    }
}
