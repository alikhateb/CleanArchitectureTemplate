using Application.Features.WebinarFeature.Query.Result;
using MediatR;

namespace Application.Features.WebinarFeature.Query.GetAll;

public class GetAllWebinarQuery : IRequest<List<WebinarResult>>
{
}