using AutoMapper;

using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.UpdateSupplier
{

    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierRequest, UpdateSupplierResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly ISupplierRepository _supplierRepository;

        //mapper
        private readonly IMapper _mapper;
        public UpdateSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSupplierResponse> Handle(UpdateSupplierRequest request, CancellationToken cancellationToken)
        {
            // buscar supplier a ser alterado
            var supplier = await _supplierRepository.Get(request.Id, cancellationToken);

            if (supplier is null) return default;

            supplier.Email = request.Email;
            supplier.SewingMachines = request.SewingMachines;
            supplier.Materials = request.Materials;
            supplier.Name = request.Name;
            supplier.Password = request.Password;


            _supplierRepository.Update(supplier);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateSupplierResponse>(supplier);


        }
    }
}

