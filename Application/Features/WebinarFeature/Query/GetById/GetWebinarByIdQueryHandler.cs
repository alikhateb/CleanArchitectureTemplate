using Application.Common.Specifications.WebinarSpecifications;
using Application.Features.WebinarFeature.Query.Result;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.WebinarFeature.Query.GetById;

public class GetWebinarByIdQueryHandler : IRequestHandler<GetWebinarByIdQuery, WebinarResult>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Webinar> _webinarRepository;

    public GetWebinarByIdQueryHandler(
        IRepository<Webinar> webinarRepository,
        IMapper mapper)

    {
        _webinarRepository = webinarRepository;
        _mapper = mapper;
    }

    public async Task<WebinarResult> Handle(
        GetWebinarByIdQuery query,
        CancellationToken cancellationToken)
    {
        var entity = await _webinarRepository
            .Find(new FindWebinarByIdSpecification(query.Id));

        if (entity is null)
        {
            throw new WebinarNotFoundException(query.Id);
        }

        var result = _mapper.Map<WebinarResult>(entity);

        return result;
    }
}