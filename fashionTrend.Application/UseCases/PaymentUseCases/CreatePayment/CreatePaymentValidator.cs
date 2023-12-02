using fashionTrend.Application.UseCases.ServiceOrderUseCases.CreateServiceOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.CreatePayment
{
    public sealed class CreatePaymentValidator : AbstractValidator<CreatePaymentRequest>
    {
        public CreatePaymentValidator()
        {
            //  RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();

        }
    }
}
