using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace fashionTrend.Application.UseCases.Notifications
{
    public class CreateNotificationHandler
    {
        private readonly IConfiguration _configuration;

        public CreateNotificationHandler(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        private void InitializeTwilioClient()
        {
            var accountSid = _configuration["TwilioAccountDetails:AccountSid"];
            var authToken = _configuration["TwilioAccountDetails:AuthToken"];

            TwilioClient.Init(accountSid, authToken);
        }

        // criar um método para fazer o envio do sms
        public void SendSMS(string toPhoneNumber, string message)
        {
            InitializeTwilioClient();

            var twilioPhoneNumber = _configuration["TwilioAccountDetails:PhoneNumber"];

            var messageOption = new CreateMessageOptions(new Twilio.Types.PhoneNumber(toPhoneNumber))
            {
                Body = message,
                From = new Twilio.Types.PhoneNumber(twilioPhoneNumber)
            };

            // buscando o retorno que veio da requisição do twillio
            var messageResponse = MessageResource.Create(messageOption);

            // verificar se a notificação foi enviada
            // se não enviar, criar uma log, para ser feita a retentativa

            // construir tratatmento de erros

            Console.WriteLine("Sms enviado com sucesso");

        }

    }
}
