using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fashionTrend.Domain.Enuns;

namespace fashionTrend.Domain.Entities
{
    public class ServiceOrder : BaseEntity
    {

        public Guid SupplierId { get; set; }
        public Guid ServiceId { get; set; }
        public RequestStatus Status { get; set; }
        public DateTimeOffset EstimatedDate { get; set; }
    }
}
