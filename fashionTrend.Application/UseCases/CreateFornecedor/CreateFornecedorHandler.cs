using AutoMapper;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateFornecedor
{

    public class CreateFornecedorHandler : IRequestHandler<CreateFornecedorRequest, CreateFornecedorResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly IFornecedorRepository _fornecedorRepository;

        //mapper
        private readonly IMapper _mapper;
        public CreateFornecedorHandler(IUnitOfWork unitOfWork, IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<CreateFornecedorResponse> Handle(CreateFornecedorRequest request, CancellationToken cancellationToken)
        {
            // onde vamos mandar as infos para os banco de dados
            var fornecedor = _mapper.Map<Fornecedor>(request);

            _fornecedorRepository.Create(fornecedor);

            // aqui chama o controle transacional
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<CreateFornecedorResponse>(fornecedor);


        }
    }
}

