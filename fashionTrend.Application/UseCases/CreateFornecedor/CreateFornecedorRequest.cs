using fashionTrend.Application.UseCases.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateFornecedor
{
    public sealed record CreateFornecedorRequest(
        string Email,
        string Name,
        string CNPJ,
        string TipoMaquina,
        string Material
        ) : IRequest<CreateFornecedorResponse>
    {

    }
}
