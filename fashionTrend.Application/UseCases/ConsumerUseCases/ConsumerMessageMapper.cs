using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Messaging;

namespace fashionTrend.Application.UseCases.ConsumerUseCases
{
    public class ConsumerMessageMapper : Profile
    {
        public ConsumerMessageMapper()
        {
            CreateMap<ConsumerMessageRequest, Message>();
        }
    }
}
