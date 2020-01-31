using System;
using System.Collections.Generic;
using System.Text;
using Titini.Domain.Common;
using Titini.Domain.ValueObjects;

namespace Titini.Domain.Entities
{
    public class Cliente : Entity<int>
    {
        public Cnpj Cnpj { get; set; } = null!;
        public string RazaoSocial { get; set; } = null!;
    }
}
