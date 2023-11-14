﻿using AutoMapper;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.CreateSupplier
{

    public class CreateSupplierHandler : IRequestHandler<CreateSupplierRequest, CreateSupplierResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly ISupplierRepository _supplierRepository;

        //mapper
        private readonly IMapper _mapper;
        public CreateSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<CreateSupplierResponse> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
        {
            // onde vamos mandar as infos para os banco de dados
            var supplier = _mapper.Map<Supplier>(request);

            _supplierRepository.Create(supplier);

            // aqui chama o controle transacional
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<CreateSupplierResponse>(supplier);


        }
    }
}
