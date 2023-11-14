using AutoMapper;
using fashionTrend.Application.UseCases.SupplierUseCases.DeleteSupplier;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.DeleteService
{
    public class DeleteServiceHandler : IRequestHandler<DeleteServiceRequest, DeleteServiceResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly IServiceRepository _serviceRepository;

        //mapper
        private readonly IMapper _mapper;
        public DeleteServiceHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<DeleteServiceResponse> Handle(DeleteServiceRequest request, CancellationToken cancellationToken)
        {
            // onde vamos mandar as infos para os banco de dados
            var service = _mapper.Map<Service>(request);

            _serviceRepository.Delete(service);

            // aqui chama o controle transacional
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<DeleteServiceResponse>(service);


        }
    }
}
