using System;
using System.Collections.Generic;
using System.Text;
using Titini.Domain.Exceptions;
using Titini.Domain.ValueObjects;
using Xunit;

namespace Titini.UnitTests.Core.Domain.ValueObjects
{
    public class CnpjTests
    {
        [Theory]
        [InlineData("82882903000108", "82.882.903/0001-08")]
        [InlineData("04055601000233", "04.055.601/0002-33")]
        [InlineData("82.882.903/0001-08", "82.882.903/0001-08")]
        [InlineData("04.055.601/0002-33", "04.055.601/0002-33")]
        public void ShouldHaveCorrectValorComFormatacao(string input, string expected)
        {
            var cnpj = new Cnpj(input);

            Assert.Equal(expected, cnpj.ValorComFormatacao);
        }

        [Theory]
        [InlineData("82882903000108", "82882903000108")]
        [InlineData("04055601000233", "04055601000233")]
        [InlineData("82.882.903/0001-08", "82882903000108")]
        [InlineData("04.055.601/0002-33", "04055601000233")]
        public void ShouldHaveCorrectValorSemFormatacao(string input, string expected)
        {
            var cnpj = new Cnpj(input);

            Assert.Equal(expected, cnpj.ValorSemFormatacao);
        }

        [Theory]
        [InlineData("82882903000108", "82.882.903/0001-08")]
        [InlineData("04055601000233", "04.055.601/0002-33")]
        [InlineData("82.882.903/0001-08", "82.882.903/0001-08")]
        [InlineData("04.055.601/0002-33", "04.055.601/0002-33")]
        public void ToStringShouldBeCorrect(string input, string expected)
        {
            Assert.Equal(expected, new Cnpj(input).ToString());
        }

        [Theory]
        [InlineData("82882903000108", "82.882.903/0001-08")]
        [InlineData("04055601000233", "04.055.601/0002-33")]
        [InlineData("82.882.903/0001-08", "82.882.903/0001-08")]
        [InlineData("04.055.601/0002-33", "04.055.601/0002-33")]
        public void ImplicitConversionToStringShouldBeCorrect(string input, string expected)
        {
            Assert.Equal(expected, new Cnpj(input));
        }

        [Theory]
        [InlineData("82882903000108")]
        [InlineData("04055601000233")]
        [InlineData("82.882.903/0001-08")]
        [InlineData("04.055.601/0002-33")]
        public void ExplicitConversionFromStringShouldBeCorrect(string input)
        {
            Assert.Equal(new Cnpj(input), (Cnpj)input);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("123")]
        [InlineData("04055601000232")]
        [InlineData("04.055.601/0002-32")]
        public void ShouldThrowExceptionOnInvalidCnpj(string input)
        {
            Assert.Throws<CnpjInvalidoException>(() => new Cnpj(input));
        }
    }
}
