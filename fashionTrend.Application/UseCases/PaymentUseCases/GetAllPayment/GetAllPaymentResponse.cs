using fashionTrend.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.GetAllPayment
{
    public sealed record GetAllPaymentResponse
    {
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid OrderId { get; set; }
    }
}
