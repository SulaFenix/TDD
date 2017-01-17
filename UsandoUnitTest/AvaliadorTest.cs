using Caelum.Leilao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsandoUnitTest
{
    [TestClass]
    public class AvaliadorTest
    {
        [TestMethod]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            // 1ª parte: Cenário
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            // 2ª parte: Ação
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // 3ª parte: Validação
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);
        }

        [TestMethod]
        public void OutroCenario()
        {
            // implementar....
        }

        [TestMethod]
        public void VerificandoMedia()
        {
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Media(leilao);

            double mediaEsperado = 316.67;

            Assert.AreEqual(mediaEsperado, leiloeiro.MediaLance, 0.01);
        }
    }
}
