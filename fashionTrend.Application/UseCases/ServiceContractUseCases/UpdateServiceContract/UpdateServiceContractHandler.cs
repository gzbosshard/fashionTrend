using AutoMapper;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.UpdateServiceContract
{
    public class UpdateServiceContractHandler : IRequestHandler<UpdateServiceContractRequest, UpdateServiceContractResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly IServiceContractRepository _serviceContractRepository;

        //mapper
        private readonly IMapper _mapper;
        public UpdateServiceContractHandler(IUnitOfWork unitOfWork, IServiceContractRepository serviceContractRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceContractRepository = serviceContractRepository;
            _mapper = mapper;
        }

        public async Task<UpdateServiceContractResponse> Handle(UpdateServiceContractRequest request, CancellationToken cancellationToken)
        {

            var serviceContract = await _serviceContractRepository.Get(request.Id, cancellationToken);

            if (serviceContract is null) return default;

            serviceContract.Order = request.Order;
            serviceContract.SupplierId = request.SupplierId;
            serviceContract.StartDate = request.StartDate;
            serviceContract.EndDate = request.EndDate;


            _serviceContractRepository.Update(serviceContract);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateServiceContractResponse>(serviceContract);


        }
    }
}
