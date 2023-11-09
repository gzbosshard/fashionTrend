﻿using AutoMapper;
using fashionTrend.Application.UseCases.CreateFornecedor;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateService
{
    public class CreateServiceHandler : IRequestHandler<CreateServiceRequest, CreateServiceResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly IServiceRepository _serviceRepository;

        //mapper
        private readonly IMapper _mapper;
        public CreateServiceHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<CreateServiceResponse> Handle(CreateServiceRequest request, CancellationToken cancellationToken)
        {
            // onde vamos mandar as infos para os banco de dados
            var service = _mapper.Map<Service>(request);

            _serviceRepository.Create(service);

            // aqui chama o controle transacional
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<CreateServiceResponse>(service);


        }
    }
}
