using fashionTrend.Application.UseCases.SupplierUseCases.GetSupplierById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.GetPaymentByOrder
{
    public class GetPaymentByOrderValidator : AbstractValidator<GetPaymentByOrderRequest>
    {
        public GetPaymentByOrderValidator()
        {
            // sem validação
        }
    }
}
