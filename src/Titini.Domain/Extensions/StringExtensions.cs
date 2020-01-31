using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace Titini.Domain.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Retirar todos os caracteres que não são números de uma string
        /// </summary>
        /// <param name="mixedString">String que potencialmente contém letras e números</param>
        /// <returns>String contendo somente os números</returns>
        public static string GetNumbers([NotNull]this string mixedString)
        {
            if (mixedString == null)
            {
                throw new ArgumentNullException();
            }

            return Regex.Replace(mixedString, "[^0-9]", "").Trim();
        }

        /// <summary>
        /// Formata uma string no formato de exibição de um cnpj
        /// </summary>
        /// <param name="cnpj">String contendo um cnpj potencialmente mal formatado</param>
        /// <returns>String de um CNPJ formatado para exibição</returns>
        public static string ToCnpj([NotNull]this string cnpj)
        {
            if (cnpj == null)
            {
                throw new ArgumentNullException();
            }
            if (cnpj.Length != 14 || !Regex.IsMatch(cnpj, @"^\d{14}$"))
            {
                throw new ArgumentOutOfRangeException();
            }
            return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }

        /// <summary>
        /// Verifica se a string é um CNPJ válido
        /// </summary>
        /// <param name="cnpj">String de um CNPJ para ser validado</param>
        /// <returns>True caso seja válido e False caso não seja</returns>
        /// Inspiração: http://www.macoratti.net/11/09/c_val1.htm
        public static bool IsValidCnpj([NotNull]this string cnpj)
        {
            cnpj = cnpj.GetNumbers();

            if (cnpj.Length == 14)
            {
                int[] multiplicadorInicial = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

                int[] multiplicadorFinal = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

                string tempCnpj = cnpj.Substring(0, 12);

                int soma = 0;

                for (int i = 0; i < 12; i++)
                {
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicadorInicial[i];
                }

                int resto = soma % 11;

                resto = resto < 2 ? 0 : 11 - resto;

                string digito = resto.ToString();

                tempCnpj += digito;

                soma = 0;

                for (int i = 0; i < 13; i++)
                {
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicadorFinal[i];
                }

                resto = soma % 11;

                resto = resto < 2 ? 0 : 11 - resto;

                digito += resto.ToString();

                return cnpj.EndsWith(digito);
            }

            return false;
        }
    }
}
