using FluentValidation;

namespace Application.Features.WebinarFeature.Command.Update
{
    public class UpdateWebinarCommandValidator : AbstractValidator<UpdateWebinarCommand>
    {
        public UpdateWebinarCommandValidator()
        {
            RuleFor(e => e.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
