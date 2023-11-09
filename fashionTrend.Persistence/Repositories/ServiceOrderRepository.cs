using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Persistence.Repositories
{
    internal class ServiceOrderRepository : BaseRepository<ServiceOrder>, IServiceOrderRepository
    {
        public ServiceOrderRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
