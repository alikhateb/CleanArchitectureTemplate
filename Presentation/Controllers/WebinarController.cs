using Application.Features.WebinarFeature.Command.Create;
using Application.Features.WebinarFeature.Command.Delete;
using Application.Features.WebinarFeature.Command.Update;
using Application.Features.WebinarFeature.Query.GetAll;
using Application.Features.WebinarFeature.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Common;

namespace Presentation.Controllers;

public class WebinarController : BaseApiController
{
    public WebinarController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpGet(Route.WebinarRoute.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetAllWebinarQuery(), cancellationToken));
    }

    [HttpGet(Route.WebinarRoute.GetById)]
    public async Task<IActionResult> GetById(Guid id,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetWebinarByIdQuery(id), cancellationToken));
    }

    [HttpPost(Route.WebinarRoute.Create)]
    public async Task<IActionResult> Create([FromBody] CreateWebinarCommand command,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    [HttpPut(Route.WebinarRoute.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateWebinarCommand command,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    [HttpDelete(Route.WebinarRoute.Delete)]
    public async Task<IActionResult> Delete(Guid id,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new DeleteWebinarCommand(id), cancellationToken));
    }
}