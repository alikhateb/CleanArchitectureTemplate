using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Features.WebinarFeature.Command.Create;

public class CreateWebinarCommandHandler : IRequestHandler<CreateWebinarCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Webinar> _webinarRepository;

    public CreateWebinarCommandHandler(
        IRepository<Webinar> webinarRepository,
        IUnitOfWork unitOfWork)
    {
        _webinarRepository = webinarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(
        CreateWebinarCommand command,
        CancellationToken cancellationToken)
    {
        var entity = new Webinar(Guid.NewGuid(), command.Name, command.ScheduledOn);

        await _webinarRepository.AddAsync(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}