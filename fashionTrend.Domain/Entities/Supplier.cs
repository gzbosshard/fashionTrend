using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fashionTrend.Domain.Enuns;

namespace fashionTrend.Domain.Entities
{
    public sealed class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        
        public List<Material> Materials { get; set; }
        public string Password {get; set;}
        public List<SewingMachine> SewingMachines { get; set; }

    }
}
