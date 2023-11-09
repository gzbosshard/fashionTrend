using fashionTrend.Application.UseCases.CreateService;
using fashionTrend.Application.UseCases.CreateServiceOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace fashionTrend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        IMediator _mediator;


        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceRequest request)
        {
            var service = await _mediator.Send(request);
            return Ok(service);
        }

    }
}
