using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class PalindromoTest
    {
        [Test]
        public void DeveIdentificarPalindromo()
        {
            Palindromo frase = new Palindromo();

            bool resultado = frase.EhPalindromo("Socorram-me subi no onibus em Marrocos");

            Assert.IsTrue(resultado);
        }

        [Test]
        public void DeveIdentificarSeNaoEhPalindromo()
        {
            Palindromo p = new Palindromo();

            bool resultado = p.EhPalindromo("123 testando");

            Assert.IsFalse(resultado);
        }
    }
}
