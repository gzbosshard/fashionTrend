using AutoMapper;
using fashionTrend.Application.UseCases.Notifications;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using fashionTrend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.UpdateServiceContract
{
    public class UpdateServiceContractHandler : IRequestHandler<UpdateServiceContractRequest, UpdateServiceContractResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceContractRepository _serviceContractRepository;
        private readonly IMapper _mapper;
        public UpdateServiceContractHandler(IUnitOfWork unitOfWork, IServiceContractRepository serviceContractRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceContractRepository = serviceContractRepository;
            _mapper = mapper;
        }

        public async Task<UpdateServiceContractResponse> Handle(UpdateServiceContractRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var serviceContract = await _serviceContractRepository.Get(request.Id, cancellationToken);

                if (serviceContract is null)
                {
                    throw new ArgumentNullException("Contrato não encontrado");
                }

                serviceContract.Order = request.Order;
                serviceContract.SupplierId = request.SupplierId;
                serviceContract.StartDate = request.StartDate;
                serviceContract.EndDate = request.EndDate;
                serviceContract.ContractStatus = request.ContractStatus;


                _serviceContractRepository.Update(serviceContract);
                await _unitOfWork.Commit(cancellationToken);

                // notificações de que a ordem de serviço foi completada

                var builder = new ConfigurationBuilder()
                .AddUserSecrets<CreateNotificationHandler>();

                var configuration = builder.Build();

                var notificaton = new CreateNotificationHandler(configuration);

                switch (request.ContractStatus)
                {
                    case ContractStatus.Approved:
                        notificaton.SendSMS("+5519982220048", $"O contrato aprovado"); break;
                    case ContractStatus.Rejected:
                        notificaton.SendSMS("+5519982220048", $"O contrato foi rejeitado"); break;
                    case ContractStatus.Pending:
                        notificaton.SendSMS("+5519982220048", $"O contrato está pendente"); break;
                    case ContractStatus.Completed:
                        notificaton.SendSMS("+5519982220048", $"O contrato está finalizado"); break;
                    default:
                        notificaton.SendSMS("+5519982220048", $"O Status do contrato foi alterado!"); break;

                }

                return _mapper.Map<UpdateServiceContractResponse>(serviceContract);
            }catch (Exception) { throw; }

        }
    }
}
