using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.GetAllService;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.GetAllServiceOrder
{
    public class GetAllServiceOrderMapper : Profile
    {
        public GetAllServiceOrderMapper()
        {
            CreateMap<ServiceOrder, GetAllServiceOrderResponse>();
        }
    }
}
