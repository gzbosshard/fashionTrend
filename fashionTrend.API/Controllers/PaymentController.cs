using fashionTrend.Application.UseCases.PaymentUseCases.CreatePayment;
using fashionTrend.Application.UseCases.PaymentUseCases.GetAllPayment;
using fashionTrend.Application.UseCases.PaymentUseCases.GetPaymentByOrder;
using fashionTrend.Application.UseCases.ServiceContractUseCases.CreateServiceContract;
using fashionTrend.Application.UseCases.ServiceUseCases.GetAllService;
using fashionTrend.Application.UseCases.SupplierUseCases.GetSupplierById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fashionTrend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentRequest request)
        {
            var payment = await _mediator.Send(request);
            return Ok(payment);
        }
        /*
        [HttpGet]
        public async Task<ActionResult<List<GetAllPaymentResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllPaymentRequest(), cancellationToken);
            return Ok(response);
        }*/

        [HttpGet("{orderId}")]
        public async Task<ActionResult<GetPaymentByOrderResponse>> GetByOrder(Guid? orderId, CancellationToken cancellationToken)
        {
            if (orderId is null) { return BadRequest(); }

            var request = new GetPaymentByOrderRequest(orderId.Value);
            var response = await _mediator.Send(request, cancellationToken);

            if (response is null) { return NotFound(); }
            return Ok(response);
        }
    }
}
