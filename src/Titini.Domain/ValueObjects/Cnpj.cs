using System;
using System.Collections.Generic;
using System.Text;
using Titini.Domain.Common;
using Titini.Domain.Exceptions;
using Titini.Domain.Extensions;

namespace Titini.Domain.ValueObjects
{
    /// <summary>
    /// Exemplo de uma implementação de Value Object
    /// </summary>
    public class Cnpj : ValueObject
    {
        public Cnpj(string cnpjString)
        {
            try
            {
                string cnpjToTest = string.Empty;

                // Verifica se já veio formatado
                if (cnpjString.Length == 18 && cnpjString.GetNumbers().Length == 14)
                {
                    cnpjToTest = cnpjString.GetNumbers();
                }
                else
                {
                    cnpjToTest = cnpjString;
                }

                // Valida se os digitos são válidos
                if (cnpjToTest.IsValidCnpj())
                {
                    ValorSemFormatacao = cnpjToTest;
                }
                else
                {
                    throw new CnpjInvalidoException(cnpjString);
                }
            }
            catch (Exception ex)
            {
                throw new CnpjInvalidoException(cnpjString, ex);
            }
        }

        public string ValorSemFormatacao { get; private set; }

        public string ValorComFormatacao => ValorSemFormatacao.ToCnpj();

        public static implicit operator string(Cnpj cnpj)
        {
            return cnpj.ToString();
        }

        public static explicit operator Cnpj(string cnpj)
        {
            return new Cnpj(cnpj);
        }

        public override string ToString()
        {
            return ValorComFormatacao;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ValorSemFormatacao;
        }
    }
}
