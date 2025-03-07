using FluentValidation;
using ToDo.Api.Dtos;

namespace ToDo.Api.Validators;
public class TodoValidator : AbstractValidator<TodoDto>
{
    public TodoValidator()
    {
        RuleFor(t => t.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(255).WithMessage("Title must not exceed 255 characters.");

        RuleFor(t => t.Description)
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

        RuleFor(t => t.IsCompleted)
            .NotNull().WithMessage("IsCompleted is required.");
    }
}