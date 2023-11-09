using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Persistence.Repositories
{
    internal class ServiceContractRepository : BaseRepository<ServiceContract>, IServiceContractRepository
    {
        public ServiceContractRepository(AppDbContext context) : base(context)
        {

        }
    }
}
