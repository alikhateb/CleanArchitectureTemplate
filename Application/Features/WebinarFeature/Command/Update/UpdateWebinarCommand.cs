using MediatR;

namespace Application.Features.WebinarFeature.Command.Update;

public class UpdateWebinarCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime ScheduledOn { get; set; }
}