using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Caelum.Leilao;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class MatematicaMalucaTest
    {
        [Test]
        public void TestaValorMaiorQue30()
        {
            MatematicaMaluca m = new MatematicaMaluca();

            int resultado = m.ContaMaluca(40);

            Assert.AreEqual(160, resultado);
        }

        [Test]
        public void TestaValorMaiorQue10EMenorQue30()
        {
            MatematicaMaluca m = new MatematicaMaluca();

            int resultado = m.ContaMaluca(20);

            Assert.AreEqual(60, resultado);
        }

        [Test]
        public void TestaValorMenorQue10()
        {
            MatematicaMaluca m = new MatematicaMaluca();

            int resultado = m.ContaMaluca(5);

            Assert.AreEqual(10, resultado);
        }

        [Test]
        public void TestaValorIgualA30()
        {
            MatematicaMaluca m = new MatematicaMaluca();

            int resultado = m.ContaMaluca(30);

            Assert.AreEqual(90, resultado);
        }

        [Test]
        public void TestaValorIgualA10()
        {
            MatematicaMaluca m = new MatematicaMaluca();

            int resultado = m.ContaMaluca(10);

            Assert.AreEqual(20, resultado);
        }
    }
}
