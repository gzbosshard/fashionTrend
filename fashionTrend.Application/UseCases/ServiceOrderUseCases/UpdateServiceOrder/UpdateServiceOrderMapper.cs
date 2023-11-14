using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.UpdateService;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.UpdateServiceOrder
{
    public class UpdateServiceOrderMapper : Profile
    {
        public UpdateServiceOrderMapper()
        {
            CreateMap<UpdateServiceOrderRequest, ServiceOrder>();
            CreateMap<ServiceOrder, UpdateServiceOrderResponse>();
        }
    }
}
