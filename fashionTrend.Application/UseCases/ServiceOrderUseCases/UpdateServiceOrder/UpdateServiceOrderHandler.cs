using AutoMapper;
using fashionTrend.Application.UseCases.Notifications;
using fashionTrend.Application.UseCases.ServiceUseCases.UpdateService;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.UpdateServiceOrder
{
    public class UpdateServiceOrderHandler : IRequestHandler<UpdateServiceOrderRequest, UpdateServiceOrderResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IMapper _mapper;
        public UpdateServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceOrderRepository = serviceOrderRepository;
            _mapper = mapper;
        }

        public async Task<UpdateServiceOrderResponse> Handle(UpdateServiceOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {

            
            var serviceOrder = await _serviceOrderRepository.Get(request.Id, cancellationToken);

                if (serviceOrder is null)
                {
                    throw new ArgumentNullException("Ordem de serviço não encontrada");
                }

            serviceOrder.SupplierId = request.SupplierId;
            serviceOrder.ServiceId = request.ServiceId;
            serviceOrder.Status = request.Status;
            serviceOrder.EstimatedDate = request.EstimatedDate;


            _serviceOrderRepository.Update(serviceOrder);
            await _unitOfWork.Commit(cancellationToken);

            // notificações de que a ordem de serviço foi completada

            var builder = new ConfigurationBuilder()
            .AddUserSecrets<CreateNotificationHandler>();

            var configuration = builder.Build();

            var notificaton = new CreateNotificationHandler(configuration);

            switch (request.Status)
            {
                case RequestStatus.Approved:
                    notificaton.SendSMS("+5519982220048", $"O serviço foi aprovado"); break;

                case RequestStatus.Rejected:
                    notificaton.SendSMS("+5519982220048", $"O serviço foi rejeitado"); break;
                case RequestStatus.Pending:
                    notificaton.SendSMS("+5519982220048", $"O serviço está pendente"); break;
                case RequestStatus.Completed:
                    notificaton.SendSMS("+5519982220048", $"O serviço está finalizado e é hora de fazer o pagamento"); break;
                default:
                    notificaton.SendSMS("+5519982220048", $"O Status do Serviço foi alterado!"); break;

            }

            return _mapper.Map<UpdateServiceOrderResponse>(serviceOrder);
            }catch(Exception) { throw; }

        }
    }
}
