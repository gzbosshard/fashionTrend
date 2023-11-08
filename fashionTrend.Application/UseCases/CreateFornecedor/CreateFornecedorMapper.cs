using AutoMapper;
using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateFornecedor
{
    public class CreateFornecedorMapper : Profile
    {
        public CreateFornecedorMapper()
        {
            CreateMap<CreateFornecedorRequest, Fornecedor>();
            CreateMap<Fornecedor, CreateFornecedorResponse>();
        }
    }
}
