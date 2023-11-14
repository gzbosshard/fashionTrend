using AutoMapper;
using fashionTrend.Application.UseCases.SupplierUseCases.UpdateSupplier;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.UpdateService
{
    public class UpdateServiceHandler : IRequestHandler<UpdateServiceRequest, UpdateServiceResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly IServiceRepository _serviceRepository;

        //mapper
        private readonly IMapper _mapper;
        public UpdateServiceHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<UpdateServiceResponse> Handle(UpdateServiceRequest request, CancellationToken cancellationToken)
        {
            
            var service = await _serviceRepository.Get(request.Id, cancellationToken);

            if (service is null) return default;

            service.Description = request.Description;
            service.Delivery = request.Delivery;
            service.SewingMachines = request.SewingMachines;
            service.Materials = request.Materials;
            service.Type = request.Type;


            _serviceRepository.Update(service);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateServiceResponse>(service);


        }
    }
}
