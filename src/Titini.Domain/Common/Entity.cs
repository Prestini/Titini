using System;
using System.Collections.Generic;
using System.Text;

namespace Titini.Domain.Common
{
    public abstract class Entity<TKey> : Entity where TKey : struct
    {
        public TKey Id { get; set; }
    }

    public abstract class Entity
    {
        public DateTime DataCriacao { get; set; }
        public string UsuarioCriacao { get; set; } = null!;
        public DateTime DataUltimaAlteracao { get; set; }
        public string UsuarioUltimaAlteracao { get; set; } = null!;
    }
}
