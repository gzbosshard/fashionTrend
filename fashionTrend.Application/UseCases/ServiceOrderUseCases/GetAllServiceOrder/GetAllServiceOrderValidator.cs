using fashionTrend.Application.UseCases.ServiceUseCases.GetAllService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.GetAllServiceOrder
{
    public class GetAllServiceOrderValidator : AbstractValidator<GetAllServiceOrderRequest>
    {
        public GetAllServiceOrderValidator()
        {
            // sem validação
        }
    }
}
