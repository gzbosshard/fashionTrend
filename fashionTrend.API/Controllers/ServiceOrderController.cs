using fashionTrend.Application.UseCases.CreateFornecedor;
using fashionTrend.Application.UseCases.CreateServiceOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace fashionTrend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        IMediator _mediator;


        public ServiceOrderController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceOrderRequest request)
        {
            var serviceOrder = await _mediator.Send(request);
            return Ok(serviceOrder);
        }




    }
}
