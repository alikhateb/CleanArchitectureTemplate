using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Common
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly IMediator Mediator;
        public BaseApiController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
