using AutoMapper;
using fashionTrend.Application.UseCases.SupplierUseCases.GetAllSupplier;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.GetAllService
{
    public class GetAllServiceMapper : Profile
    {
        public GetAllServiceMapper()
        {
            CreateMap<Service, GetAllServiceResponse>();
        }
    }
}
