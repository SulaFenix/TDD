using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {
        [Test]
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

        [Test]
        public void OutroCenario()
        {
            // implementar....
        }

        [Test]
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

        [Test]      
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Usuario joao = new Usuario("Joao");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 1000.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 400.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemAleatoria()
        {
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 450.0));
            leilao.Propoe(new Lance(jose, 120.0));
            leilao.Propoe(new Lance(maria, 700.0));
            leilao.Propoe(new Lance(joao, 630.0));
            leilao.Propoe(new Lance(jose, 230.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(120, leiloeiro.MenorLance, 0.0001);
            Assert.AreEqual(700, leiloeiro.MaiorLance, 0.0001);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 400.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 100.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(100, leiloeiro.MenorLance, 0.0001);
            Assert.AreEqual(400, leiloeiro.MaiorLance, 0.0001);
        }

        [Test]
        public void DeveDevolverTodosOsLancesCasoNaoHajaNoMinimo3()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(200, maiores[0].Valor, 0.0001);
            Assert.AreEqual(100, maiores[1].Valor, 0.0001);
        }

        [Test]
        public void DeveDevolverListaVaziaCasoNaoHajaLances()
        {
            Leilao leilao = new Leilao("Playstation 3 Novo");

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(0, maiores.Count);
        }
    }
}
