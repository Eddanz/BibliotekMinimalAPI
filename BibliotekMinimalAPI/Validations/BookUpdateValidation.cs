using BibliotekMinimalAPI.Models.DTOs;
using FluentValidation;

namespace BibliotekMinimalAPI.Validations
{
    public class BookUpdateValidation : AbstractValidator<BookUpdateDTO>
    {
        public BookUpdateValidation()
        {
            RuleFor(model => model.Id).NotEmpty();
            RuleFor(model => model.Title).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(model => model.Author).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(model => model.Genre).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(model => model.Description).NotEmpty().MinimumLength(25);
        }
    }
}
