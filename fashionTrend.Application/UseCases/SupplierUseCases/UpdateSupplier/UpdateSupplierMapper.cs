using AutoMapper;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.UpdateSupplier
{
    public class UpdateSupplierMapper : Profile
    {
        public UpdateSupplierMapper()
        {
            CreateMap<UpdateSupplierRequest, Supplier>();
            CreateMap<Supplier, UpdateSupplierResponse>();
        }
    }
}
