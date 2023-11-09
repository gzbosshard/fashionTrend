using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Persistence.Repositories
{
    internal class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context)
        {

        }
    }
}
