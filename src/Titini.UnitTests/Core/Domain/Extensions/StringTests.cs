using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Titini.Domain.Extensions;

namespace Titini.UnitTests.Core.Domain.Extensions
{
    public class StringTests
    {
        #region GetNumbers

        [Theory]
        [InlineData("A172202B", "172202")]
        [InlineData("A1B2C3", "123")]
        [InlineData("letras e 1 numero", "1")]
        public void GetNumbers_ShouldGetOnlyNumbersFromString(string input, string expected)
        {
            var realResult = input.GetNumbers();

            Assert.Equal(expected, realResult);
        }

        [Fact]
        public void GetNumbers_ShouldThrowExceptionOnNull()
        {
            string nullString = null;

            Assert.Throws<ArgumentNullException>(() => nullString.GetNumbers());
        }

        #endregion

        #region ToCnpj

        [Theory]
        [InlineData("82882903000108", "82.882.903/0001-08")]
        [InlineData("04055601000233", "04.055.601/0002-33")]
        public void ToCnpj_ShouldConvertValidNumbersToCnpj(string input, string expected)
        {
            var realResult = input.ToCnpj();

            Assert.Equal(expected, realResult);
        }

        [Theory]
        [InlineData("8288290300010882882903000108")]
        [InlineData("1234567890")]
        [InlineData("8288290__00108")]
        public void ToCnpj_ShouldThrowExceptionOnInvalidString(string input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => input.ToCnpj());
        }

        [Fact]
        public void ToCnpj_ShouldThrowExceptionOnNull()
        {
            string nullString = null;

            Assert.Throws<ArgumentNullException>(() => nullString.ToCnpj());
        }

        #endregion

        #region IsValidCnpj

        [Theory]
        [InlineData("82882903000108")]
        [InlineData("82.882.903/0001-08")]
        [InlineData("04055601000233")]
        [InlineData("04.055.601/0002-33")]
        public void IsValidCnpj_ShouldReturnTrueOnValidStrings(string input)
        {
            Assert.True(input.IsValidCnpj());
        }

        [Theory]
        [InlineData("82882903000107")]
        [InlineData("82.882.903/0001-07")]
        [InlineData("04055601000232")]
        [InlineData("04.055.601/0002-32")]
        public void IsValidCnpj_ShouldReturnFalseOnInvalidStrings(string input)
        {
            Assert.False(input.IsValidCnpj());
        }

        #endregion
    }
}
