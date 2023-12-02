using AutoMapper;
using fashionTrend.Application.UseCases.Notifications;
using fashionTrend.Application.UseCases.ServiceOrderUseCases.CreateServiceOrder;
using fashionTrend.Application.UseCases.ServiceUseCases.CreateService;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.CreatePayment
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentRequest, CreatePaymentResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public CreatePaymentHandler(IUnitOfWork unitOfWork, IPaymentRepository paymentRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<CreatePaymentResponse> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var payment = _mapper.Map<Payment>(request);
                _paymentRepository.Create(payment);
                await _unitOfWork.Commit(cancellationToken);


                // notificações de pagamento

                var builder = new ConfigurationBuilder()
                .AddUserSecrets<CreateNotificationHandler>();

                var configuration = builder.Build();
                var notificaton = new CreateNotificationHandler(configuration);

                notificaton.SendSMS("+5519982220048", "O pagamento foi realizado");

                return _mapper.Map<CreatePaymentResponse>(payment);
            }
            catch (Exception) { throw; }



        }
    }
}
