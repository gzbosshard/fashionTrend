using AutoMapper;
using fashionTrend.Application.UseCases.SupplierUseCases.GetAllSupplier;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.GetSupplierById
{
    public class GetSupplierByIdMapper : Profile
    {
        public GetSupplierByIdMapper()
        {
            CreateMap<Supplier, GetSupplierByIdResponse>();
        }
    }
}
