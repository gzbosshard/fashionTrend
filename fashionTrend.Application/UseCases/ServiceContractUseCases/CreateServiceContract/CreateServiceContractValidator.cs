﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.CreateServiceContract
{
    public sealed class CreateServiceContractValidator : AbstractValidator<CreateServiceContractRequest>
    {
        public CreateServiceContractValidator()
        {
            //  RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();

        }
    }
}