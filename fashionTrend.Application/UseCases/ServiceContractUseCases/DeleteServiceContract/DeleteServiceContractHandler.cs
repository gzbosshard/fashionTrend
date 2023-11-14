﻿using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.DeleteService;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.DeleteServiceContract
{
    public class DeleteServiceContractHandler : IRequestHandler<DeleteServiceContractRequest, DeleteServiceContractResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly IServiceContractRepository _serviceContractRepository;

        //mapper
        private readonly IMapper _mapper;
        public DeleteServiceContractHandler(IUnitOfWork unitOfWork, IServiceContractRepository serviceContractRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceContractRepository = serviceContractRepository;
            _mapper = mapper;
        }

        public async Task<DeleteServiceContractResponse> Handle(DeleteServiceContractRequest request, CancellationToken cancellationToken)
        {
            // onde vamos mandar as infos para os banco de dados
            var serviceContract = _mapper.Map<ServiceContract>(request);

            _serviceContractRepository.Delete(serviceContract);

            // aqui chama o controle transacional
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<DeleteServiceContractResponse>(serviceContract);


        }
    }
}