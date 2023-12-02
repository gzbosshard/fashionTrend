using AutoMapper;
using fashionTrend.Application.UseCases.ServiceOrderUseCases.CreateServiceOrder;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.CreatePayment
{
    public class CreatePaymentMapper : Profile
    {
        public CreatePaymentMapper()
        {
            CreateMap<CreatePaymentRequest, Payment>();
            CreateMap<Payment, CreatePaymentResponse>();
        }
    }
}
