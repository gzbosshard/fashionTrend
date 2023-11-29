using AutoMapper;
using fashionTrend.Application.UseCases.SupplierUseCases.GetSupplierById;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.GetSupplierById
{
    public sealed class GetSupplierByIdHandler : IRequestHandler<GetSupplierByIdRequest, GetSupplierByIdResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierByIdHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<GetSupplierByIdResponse> Handle(GetSupplierByIdRequest request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<GetSupplierByIdResponse>(suppliers);
        }

    }
}
