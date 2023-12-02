using AutoMapper;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.GetAllServiceContract
{
    public sealed class GetAllServiceContractHandler : IRequestHandler<GetAllServiceContractRequest, List<GetAllServiceContractResponse>>
    {
        private readonly IServiceContractRepository _serviceContractRepository;
        private readonly IMapper _mapper;

        public GetAllServiceContractHandler(IServiceContractRepository serviceContractRepository, IMapper mapper)
        {
            _serviceContractRepository = serviceContractRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllServiceContractResponse>> Handle(GetAllServiceContractRequest request, CancellationToken cancellationToken)
        {
            try
            {            
            var serviceContract = await _serviceContractRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllServiceContractResponse>>(serviceContract);
            } catch (Exception) { throw; }
        }
    }
}
