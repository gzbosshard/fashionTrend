using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.GetAllService;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.GetAllPayment
{
    public class GetAllPaymentMapper : Profile
    {
        public GetAllPaymentMapper()
        {
            CreateMap<Payment, GetAllPaymentResponse>();
        }
    }
}
