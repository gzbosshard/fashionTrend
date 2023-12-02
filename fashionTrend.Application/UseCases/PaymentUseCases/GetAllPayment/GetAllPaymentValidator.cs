using fashionTrend.Application.UseCases.ServiceUseCases.GetAllService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.GetAllPayment
{
    public class GetAllPaymentValidator : AbstractValidator<GetAllPaymentRequest>
    {
        public GetAllPaymentValidator()
        {
            // sem validação
        }
    }
}
