using AutoMapper;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.CreateService
{
    public class CreateServiceMapper : Profile
    {
        public CreateServiceMapper()
        {
            CreateMap<CreateServiceRequest, Service>();
            CreateMap<Service, CreateServiceResponse>();
        }
    }
}
