using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace fashionTrend.Application.UseCases.CreateUser
{
    // Passamos todas as propriedades como parâmetros no construtor da classe
    public sealed record CreateUserRequest (
        string Email,
        string Name,
        string Password
        ) : IRequest<CreateUserResponse>
    {

    }
}
