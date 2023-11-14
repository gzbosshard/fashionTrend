using AutoMapper;
using fashionTrend.Application.UseCases.SupplierUseCases.UpdateSupplier;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.UpdateService
{
    public class UpdateServiceMapper : Profile
    {
        public UpdateServiceMapper()
        {
            CreateMap<UpdateServiceRequest, Service>();
            CreateMap<Service, UpdateServiceResponse>();
        }
    }
}
