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
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly IPaymentRepository _paymentRepository;

        //mapper
        private readonly IMapper _mapper;
        public CreatePaymentHandler(IUnitOfWork unitOfWork, IPaymentRepository paymentRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<CreatePaymentResponse> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
        {
            // onde vamos mandar as infos para os banco de dados
            var payment = _mapper.Map<Payment>(request);

            _paymentRepository.Create(payment);

            // aqui chama o controle transacional
            await _unitOfWork.Commit(cancellationToken);
            

            // notificações de pagamento

            var builder = new ConfigurationBuilder()
            .AddUserSecrets<CreateNotificationHandler>();

            var configuration = builder.Build();

            var notificaton = new CreateNotificationHandler(configuration);


            notificaton.SendSMS("+5519982220048", "O pagamento foi realizado");

            return _mapper.Map<CreatePaymentResponse>(payment);




        }
    }
}
