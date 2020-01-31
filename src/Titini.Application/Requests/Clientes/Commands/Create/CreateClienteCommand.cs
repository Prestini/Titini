using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Titini.Application.Common.Interfaces;
using Titini.Domain.Entities;
using Titini.Domain.ValueObjects;

namespace Titini.Application.Requests.Clientes.Commands.Create
{
    public class CreateClienteCommand : IRequest<CreateClienteCommandResult>
    {
        public string Cnpj { get; set; } = null!;
        public string RazaoSocial { get; set; } = null!;

        public class Handler : IRequestHandler<CreateClienteCommand, CreateClienteCommandResult>
        {
            private readonly ITitiniDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ITitiniDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<CreateClienteCommandResult> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
            {
                var entity = new Cliente
                {
                    Cnpj = new Cnpj(request.Cnpj),
                    RazaoSocial = request.RazaoSocial
                };

                _context.Clientes.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<CreateClienteCommandResult>(entity);
            }
        }
    }
}
