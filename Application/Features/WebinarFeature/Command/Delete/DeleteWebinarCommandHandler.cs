using Application.Common.Repositories;
using Domain.Abstractions;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.WebinarFeature.Command.Delete;

public class DeleteWebinarCommandHandler : IRequestHandler<DeleteWebinarCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebinarRepository _webinarRepository;

    public DeleteWebinarCommandHandler(IWebinarRepository webinarRepository,
        IUnitOfWork unitOfWork)
    {
        _webinarRepository = webinarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(DeleteWebinarCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await _webinarRepository.GetByIdAsync(e => e.Id == command.Id);

        if (entity is null) throw new WebinarNotFoundException(command.Id);

        await _webinarRepository.DeleteAsync(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}