using Application.Common.Repositories;
using Application.Features.WebinarFeature.Query.Result;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.WebinarFeature.Query.GetById
{
    public class GetWebinarByIdQueryHandler : IRequestHandler<GetWebinarByIdQuery, WebinarResult>
    {
        private readonly IWebinarRepository _webinarRepository;
        private readonly IMapper _mapper;
        public GetWebinarByIdQueryHandler(IWebinarRepository webinarRepository,
            IMapper mapper)
        {
            _webinarRepository = webinarRepository;
            _mapper = mapper;
        }

        public async Task<WebinarResult> Handle(GetWebinarByIdQuery query,
            CancellationToken cancellationToken)
        {
            var entity = await _webinarRepository.GetByIdAsync(e => e.Id == query.Id);

            if (entity is null)
            {
                throw new WebinarNotFoundException(query.Id);
            }

            var result = _mapper.Map<WebinarResult>(entity);

            return result;
        }
    }
}
