using fashionTrend.Application.UseCases.ServiceUseCases.UpdateService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.UpdateServiceOrder
{
    public sealed class UpdateServiceOrderValidator : AbstractValidator<UpdateServiceOrderRequest>
    {
        public UpdateServiceOrderValidator()
        {


        }
    }
}
