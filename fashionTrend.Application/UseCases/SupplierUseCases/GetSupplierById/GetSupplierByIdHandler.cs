using AutoMapper;
using fashionTrend.Application.UseCases.SupplierUseCases.GetSupplierById;
using fashionTrend.Domain.Entities;
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
            try
            {
                var suppliers = await _supplierRepository.Get(request.Id, cancellationToken);

                if (suppliers is null)
                {
                    throw new ArgumentNullException("Fornecedor não encontrado");
                }
                return _mapper.Map<GetSupplierByIdResponse>(suppliers);
            }
            catch (Exception) { throw; }

        }

    }
}
