using System;
using System.Collections.Generic;
using System.Text;

namespace Titini.Application.Requests.Clientes.Commands.Update
{
    public class UpdateClienteCommandResult
    {
        public int Id { get; set; }
        public string Cnpj { get; set; } = null!;
        public string RazaoSocial { get; set; } = null!;
    }
}
