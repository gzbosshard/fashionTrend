using AutoMapper;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.DeleteSupplier
{
    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierRequest, DeleteSupplierResponse>
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly ISupplierRepository _supplierRepository;

        private readonly IMapper _mapper;
        public DeleteSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<DeleteSupplierResponse> Handle(DeleteSupplierRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(request);

                _supplierRepository.Delete(supplier);

                await _unitOfWork.Commit(cancellationToken);
                return _mapper.Map<DeleteSupplierResponse>(supplier);
            }
            catch (Exception) { throw; }
            


        }
    }
}
