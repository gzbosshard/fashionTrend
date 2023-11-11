using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.DeleteSupplier
{
    public sealed record DeleteSupplierResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<SewingMachine> SewingMachines { get; set; }
        public List<Material> Materials { get; set; }
        public string Description { get; set; }
    }
}
