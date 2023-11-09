using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateServiceOrder
{
    public sealed record CreateServiceOrderResponse
    {
        public Guid SupplierId { get; set; }
        public Guid ServiceId { get; set; }
        public RequestStatus Status { get; set; }
        public DateTimeOffset EstimatedDate { get; set; }
    }
}
