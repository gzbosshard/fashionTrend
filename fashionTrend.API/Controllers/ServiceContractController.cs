using fashionTrend.Application.UseCases.ServiceContractUseCases.CreateServiceContract;
using fashionTrend.Application.UseCases.ServiceContractUseCases.DeleteServiceContract;
using fashionTrend.Application.UseCases.ServiceContractUseCases.GetAllServiceContract;
using fashionTrend.Application.UseCases.ServiceContractUseCases.UpdateServiceContract;
using fashionTrend.Application.UseCases.SupplierUseCases.DeleteSupplier;
using fashionTrend.Application.UseCases.SupplierUseCases.GetAllSupplier;
using fashionTrend.Application.UseCases.SupplierUseCases.UpdateSupplier;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace fashionTrend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceContractController : ControllerBase
    {
        IMediator _mediator;


        public ServiceContractController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceContractRequest request)
        {
            var serviceContract = await _mediator.Send(request);
            return Ok(serviceContract);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateServiceContractResponse>>
            Update(Guid id, UpdateServiceContractRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var deleteRequest = new DeleteServiceContractRequest(id.Value);
            var response = await _mediator.Send(deleteRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllServiceContractResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllServiceContractRequest(), cancellationToken);
            return Ok(response);
        }

    }
}
