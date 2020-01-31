using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Titini.Application.Requests.Clientes.Commands.Update
{
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("É necessário informar um código de Cliente.")
                .GreaterThan(0).WithMessage("O código de Cliente informado é inválido.");

            RuleFor(e => e.RazaoSocial)
                .MaximumLength(256).WithMessage("A Razão Social pode ter no máximo 256 caracteres.");
        }
    }
}
