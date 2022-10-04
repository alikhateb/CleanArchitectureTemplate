using Application.Common.Repositories;
using Application.Features.WebinarFeature.Query.Result;
using AutoMapper;
using MediatR;

namespace Application.Features.WebinarFeature.Query.GetAll;

internal class GetAllWebinarQueryHandler : IRequestHandler<GetAllWebinarQuery, List<WebinarResult>>
{
    private readonly IMapper _mapper;
    private readonly IWebinarRepository _webinarRepository;

    public GetAllWebinarQueryHandler(IWebinarRepository webinarRepository,
        IMapper mapper)
    {
        _webinarRepository = webinarRepository;
        _mapper = mapper;
    }

    public async Task<List<WebinarResult>> Handle(GetAllWebinarQuery query,
        CancellationToken cancellationToken)
    {
        var entities = await _webinarRepository.GetAllAsync();

        if (entities is null) return default;

        var result = _mapper.Map<List<WebinarResult>>(entities);

        return result;
    }
}