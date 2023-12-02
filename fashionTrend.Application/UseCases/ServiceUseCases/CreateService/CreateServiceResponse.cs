﻿using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.CreateService
{
    public sealed record CreateServiceResponse
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public bool Delivery { get; set; }
        public RequestType Type { get; set; }
        public List<SewingMachine>? SewingMachines { get; set; }
        public List<Material>? Materials { get; set; }
    }
}
