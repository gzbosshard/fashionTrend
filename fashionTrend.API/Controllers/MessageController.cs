using fashionTrend.Application.UseCases.MessageUseCases.CreateMessage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace fashionTrend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageControler : ControllerBase
    {
        IMediator _mediator;

        public MessageControler(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageRequest request)
        {
            var message = await _mediator.Send(request);
            return Ok(message);
        }
    }
}
