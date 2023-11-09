using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateService
{
    public sealed record CreateServiceResponse
    {
        public string Description { get; set; }
        public bool Delivery { get; set; }
        public RequestType Type { get; set; }
        public List<SewingMachine> SewingMachines { get; set; }
        public List<Material> Materials { get; set; }
    }
}
