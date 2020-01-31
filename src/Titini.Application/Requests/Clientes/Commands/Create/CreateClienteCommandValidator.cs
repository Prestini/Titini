using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Titini.Domain.Extensions;

namespace Titini.Application.Requests.Clientes.Commands.Create
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(e => e.RazaoSocial)
                .MaximumLength(256).WithMessage("A Razão Social pode ter no máximo 256 caracteres.")
                .NotEmpty().WithMessage("A Razão Social precisa ser preenchida.");

            RuleFor(e => e.Cnpj)
                .Length(14).WithMessage("Um CNPJ deve ter exatamente 14 dígitos.")
                .Matches(@"\d{14}").WithMessage("Um CNPJ deve conter apenas números.")
                .Must(cnpj => cnpj.IsValidCnpj()).WithMessage("O CNPJ informado não é válido.");
        }
    }
}
