using AutoMapper;
using fashionTrend.Application.UseCases.SupplierUseCases.DeleteSupplier;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.DeleteService
{
    public class DeleteServiceMapper : Profile
    {
        public DeleteServiceMapper()
        {
            CreateMap<DeleteServiceRequest, Service>();
            CreateMap<Service, DeleteServiceResponse>();
        }
    }
}
