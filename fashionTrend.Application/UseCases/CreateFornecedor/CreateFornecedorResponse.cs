using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateFornecedor
{
    public sealed record CreateFornecedorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string TipoMaquina { get; set; }
        public string Material { get; set; }

        // public string Password { get; set; }
    }
}
