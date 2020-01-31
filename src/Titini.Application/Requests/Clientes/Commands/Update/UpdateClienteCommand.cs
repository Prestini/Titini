using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Titini.Application.Common.Interfaces;

namespace Titini.Application.Requests.Clientes.Commands.Update
{
    public class UpdateClienteCommand : IRequest<UpdateClienteCommandResult>
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; } = null!;

        public class Handler : IRequestHandler<UpdateClienteCommand, UpdateClienteCommandResult>
        {
            private readonly ITitiniDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ITitiniDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UpdateClienteCommandResult> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                entity.RazaoSocial = request.RazaoSocial;

                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<UpdateClienteCommandResult>(entity);
            }
        }
    }
}
