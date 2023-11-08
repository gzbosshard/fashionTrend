﻿using fashionTrend.Application.UseCases.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateFornecedor
{
    public sealed class CreateFornecedorValidator : AbstractValidator<CreateFornecedorRequest>
    {
        public CreateFornecedorValidator()
        {
           RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
           RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(3);
           RuleFor(x => x.CNPJ).NotEmpty().MaximumLength(11).MinimumLength(11);
        }
    }
}
