using System;
using System.Collections.Generic;
using System.Text;

namespace Titini.Domain.Exceptions
{
    public class CnpjInvalidoException : Exception
    {
        public CnpjInvalidoException(string cnpj) : base($"O CNPJ informado ({ cnpj }) não é válido")
        {
        }

        public CnpjInvalidoException(string cnpj, Exception inner) : base($"O CNPJ informado ({ cnpj }) não é válido", inner)
        {
        }
    }
}
