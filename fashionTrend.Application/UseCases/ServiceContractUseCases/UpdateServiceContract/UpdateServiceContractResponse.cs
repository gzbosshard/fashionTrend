﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.UpdateServiceContract
{
    public sealed record UpdateServiceContractResponse
    {
        public Guid Order { get; set; }
        public Guid SupplierId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}