using Application.Common.Specifications.WebinarSpecifications;
using Application.Features.WebinarFeature.Query.Result;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Features.WebinarFeature.Query.GetAll;

internal class GetAllWebinarQueryHandler : IRequestHandler<GetAllWebinarQuery, List<WebinarResult>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Webinar> _webinarRepository;

    public GetAllWebinarQueryHandler(
        IRepository<Webinar> webinarRepository,
        IMapper mapper)
    {
        _webinarRepository = webinarRepository;
        _mapper = mapper;
    }

    public async Task<List<WebinarResult>> Handle(
        GetAllWebinarQuery query,
        CancellationToken cancellationToken)
    {
        var entities = await _webinarRepository
            .GetList(new SortWebinarSpecification(w => w.Name));

        if (entities is null)
        {
            return default;
        }

        var result = _mapper.Map<List<WebinarResult>>(entities);

        return result;
    }
}