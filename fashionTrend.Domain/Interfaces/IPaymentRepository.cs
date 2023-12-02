﻿using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Domain.Interfaces
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        public Task<Payment> GetByOrder(Guid id, CancellationToken cancellationToken);
    }
}
