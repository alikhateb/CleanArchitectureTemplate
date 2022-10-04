using MediatR;

namespace Application.Features.WebinarFeature.Command.Delete;

public class DeleteWebinarCommand : IRequest<Guid>
{
    public DeleteWebinarCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}