using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.DeleteService;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.DeleteServiceContract
{
    public class DeleteServiceContractMapper : Profile
    {
        public DeleteServiceContractMapper()
        {
            CreateMap<DeleteServiceContractRequest, ServiceContract>();
            CreateMap<ServiceContract, DeleteServiceContractResponse>();
        }
    }
}
