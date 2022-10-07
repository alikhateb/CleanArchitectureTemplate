using Application.Common.Specifications.WebinarSpecifications;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.WebinarFeature.Command.Update;

public class UpdateWebinarCommandHandler : IRequestHandler<UpdateWebinarCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Webinar> _webinarRepository;

    public UpdateWebinarCommandHandler(
        IRepository<Webinar> webinarRepository,
        IUnitOfWork unitOfWork)
    {
        _webinarRepository = webinarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(
        UpdateWebinarCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await _webinarRepository
            .Find(new FindWebinarByIdSpecification(command.Id));

        if (entity is null)
        {
            throw new WebinarNotFoundException(command.Id);
        }

        //update entity with new values
        var UpdatedEntity = new Webinar(entity.Id, command.Name, command.ScheduledOn);

        await _webinarRepository.UpdateAsync(UpdatedEntity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}