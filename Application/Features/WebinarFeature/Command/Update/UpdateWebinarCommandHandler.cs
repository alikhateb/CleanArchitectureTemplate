using Application.Common.Repositories;
using Domain.Abstractions;
using Domain.Entity;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.WebinarFeature.Command.Update;

public class UpdateWebinarCommandHandler : IRequestHandler<UpdateWebinarCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebinarRepository _webinarRepository;

    public UpdateWebinarCommandHandler(IWebinarRepository webinarRepository,
        IUnitOfWork unitOfWork)
    {
        _webinarRepository = webinarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(UpdateWebinarCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await _webinarRepository.GetByIdAsync(e => e.Id == command.Id);

        if (entity is null) throw new WebinarNotFoundException(command.Id);

        //update entity with new values
        var UpdatedEntity = new Webinar(entity.Id, command.Name, command.ScheduledOn);

        await _webinarRepository.UpdateAsync(UpdatedEntity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}