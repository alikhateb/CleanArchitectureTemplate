using Application.Common.Specifications;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.WebinarFeature.Command.Delete;

public class DeleteWebinarCommandHandler : IRequestHandler<DeleteWebinarCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Webinar> _webinarRepository;

    public DeleteWebinarCommandHandler(
        IRepository<Webinar> webinarRepository,
        IUnitOfWork unitOfWork)
    {
        _webinarRepository = webinarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(
        DeleteWebinarCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await _webinarRepository
            .FindWithSpecificationPattern(new FindWebinarByIdSpecification(command.Id));

        if (entity is null)
        {
            throw new WebinarNotFoundException(command.Id);
        }

        await _webinarRepository.DeleteAsync(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}