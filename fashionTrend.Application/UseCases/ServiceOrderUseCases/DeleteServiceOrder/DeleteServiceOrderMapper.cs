using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.DeleteService;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.DeleteServiceOrder
{
    public class DeleteServiceOrderMapper : Profile
    {
        public DeleteServiceOrderMapper()
        {
            CreateMap<DeleteServiceOrderRequest, ServiceOrder>();
            CreateMap<ServiceOrder, DeleteServiceOrderResponse>();
        }
    }
}
