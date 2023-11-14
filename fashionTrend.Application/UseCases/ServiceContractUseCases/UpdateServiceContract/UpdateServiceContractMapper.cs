using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.UpdateService;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.UpdateServiceContract
{
    public class UpdateServiceContractMapper : Profile
    {
        public UpdateServiceContractMapper()
        {
            CreateMap<UpdateServiceContractRequest, ServiceContract>();
            CreateMap<ServiceContract, UpdateServiceContractResponse>();
        }
    }
}
