using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ConsumerUseCases
{
        public sealed record ConsumerMessageRequest(string topic, string group) : IRequest<string>;
}
