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

        //configuração do twilio para utilizar usersecrets e não deixar a senha exposta.
        private void InitializeTwilioClient()
        {
            var accountSid = _configuration["TwilioAccountDetails:AccountSid"];
            var authToken = _configuration["TwilioAccountDetails:AuthToken"];

            TwilioClient.Init(accountSid, authToken);
        }

        // criar um método para fazer o envio do sms
        public void SendSMS(string toPhoneNumber, string message)
        {
            try
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

                Console.WriteLine("Sms enviado com sucesso");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocorreu um erro ao enviar a mensagem");
            }

        }

    }
}
