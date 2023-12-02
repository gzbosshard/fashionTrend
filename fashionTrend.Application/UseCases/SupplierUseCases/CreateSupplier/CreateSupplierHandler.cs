using AutoMapper;
using fashionTrend.Application.UseCases.Notifications;
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
        private readonly IUnitOfWork _unitOfWork;

        private readonly ISupplierRepository _supplierRepository;

        private readonly IMapper _mapper;
        public CreateSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<CreateSupplierResponse> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
        {
            try { 
            var supplier = _mapper.Map<Supplier>(request);

            _supplierRepository.Create(supplier);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateSupplierResponse>(supplier);

            } catch (Exception) { throw new Exception("Não foi possível criar um fornecedor"); }



        }
    }
}

