using Application.Features.WebinarFeature.Query.Result;
using MediatR;

namespace Application.Features.WebinarFeature.Query.GetById;

public class GetWebinarByIdQuery : IRequest<WebinarResult>
{
    public GetWebinarByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}