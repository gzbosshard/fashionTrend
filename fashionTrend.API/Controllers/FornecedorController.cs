using fashionTrend.Application.UseCases.CreateFornecedor;
using fashionTrend.Application.UseCases.CreateUser;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace fashionTrend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        IMediator _mediator;
        

        public FornecedorController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFornecedorRequest request)
        {
            var fornecedor = await _mediator.Send(request);
            return Ok(fornecedor);
        }
        



    }
}
