﻿using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.CreateService;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.CreateServiceContract
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
