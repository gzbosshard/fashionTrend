using AutoMapper;
using fashionTrend.Application.UseCases.CreateService;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateServiceContract
{
    public class CreateServiceContractMapper : Profile
    {
        public CreateServiceContractMapper()
        {
            CreateMap<CreateServiceContractRequest, ServiceContract>();
            CreateMap<ServiceContract, CreateServiceContractResponse>();
        }
    }
}
