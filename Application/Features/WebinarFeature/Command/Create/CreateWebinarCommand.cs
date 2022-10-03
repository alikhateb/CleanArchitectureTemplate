using MediatR;

namespace Application.Features.WebinarFeature.Command.Create
{
    public class CreateWebinarCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime ScheduledOn { get; set; }
    }
}
