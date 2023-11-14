using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.GetAllServiceOrder
{
    public sealed record GetAllServiceOrderResponse
    {
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; }
        public Guid ServiceId { get; set; }
        public RequestStatus Status { get; set; }
        public DateTimeOffset EstimatedDate { get; set; }
    }
}
