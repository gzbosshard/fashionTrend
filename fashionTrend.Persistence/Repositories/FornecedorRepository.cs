using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fashionTrend.Persistence.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(AppDbContext context) : base(context)
        {

        }


        public async Task<Fornecedor> GetByEmail(string email, CancellationToken cancellationToken)
        {

            return await Context.Fornecedores.FirstOrDefaultAsync(
                x => x.Email.Equals(email), cancellationToken);
        }
    }
}

