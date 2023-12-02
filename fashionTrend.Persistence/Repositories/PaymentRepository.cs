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
    internal class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Payment> GetByOrder(Guid orderId, CancellationToken cancellationToken)
        {
            return await Context.Set<Payment>().FirstOrDefaultAsync(
                x => x.OrderId.Equals(orderId), cancellationToken);
        }
    }
}
