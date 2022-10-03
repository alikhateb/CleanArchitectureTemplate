using FluentValidation;

namespace Application.Features.WebinarFeature.Command.Create
{
    public class CreateWebinarCommandValidatorc : AbstractValidator<CreateWebinarCommand>
    {
        public CreateWebinarCommandValidatorc()
        {
            RuleFor(e => e.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
