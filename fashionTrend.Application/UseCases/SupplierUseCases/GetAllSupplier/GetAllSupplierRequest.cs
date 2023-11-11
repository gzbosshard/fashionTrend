﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.GetAllSupplier
{
    public sealed record GetAllSupplierRequest : IRequest<List<GetAllSupplierResponse>>
    {
    }
}
