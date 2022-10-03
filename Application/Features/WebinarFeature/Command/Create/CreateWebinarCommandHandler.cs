using Application.Common.Repositories;
using Domain.Abstractions;
using Domain.Entity;
using MediatR;

namespace Application.Features.WebinarFeature.Command.Create
{
    public class CreateWebinarCommandHandler : IRequestHandler<CreateWebinarCommand, Guid>
    {
        private readonly IWebinarRepository _webinarRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWebinarCommandHandler(IWebinarRepository webinarRepository,
            IUnitOfWork unitOfWork)
        {
            _webinarRepository = webinarRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateWebinarCommand command,
            CancellationToken cancellationToken)
        {
            var entity = new Webinar(Guid.NewGuid(), command.Name, command.ScheduledOn);

            await _webinarRepository.AddAsync(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
