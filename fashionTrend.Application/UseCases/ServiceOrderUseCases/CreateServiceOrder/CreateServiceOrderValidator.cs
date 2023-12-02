using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.CreateServiceOrder
{
    public sealed class CreateServiceOrderValidator : AbstractValidator<CreateServiceOrderRequest>
    {
        public CreateServiceOrderValidator()
        {
            RuleFor(x => x.Status).NotEmpty();

        }
    }
}
